using Newtonsoft.Json;
using PrimeFuncPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace JsonSerialization;

static class SpeedTestHelper
{
    private static Stopwatch timer;

    static SpeedTestHelper()
    {
        timer = new Stopwatch();
    }

    public static IReadOnlyCollection<TargetObject> MakeBigObject()
    {
        List<TargetObject> targetObjects = new();
        for (int i = 0; i < TesterNames.Size; ++i)
        {
            targetObjects.Add(new());
        }
        return targetObjects;
    }

    public static void SpeedTest(
        Serializer serializer, IReadOnlyCollection<TargetObject> targetObjects,
        out double average, out double ds, int count = TesterNames.StatsTimes)
    {
        List<long> mesurments = new();
        for (int i = 0; i < count; ++i)
        {
            using MemoryStream ms = new();
            using Utf8JsonWriter writer = new(ms);
            timer.Reset();
            timer.Restart();
            serializer(writer, targetObjects);
            timer.Stop();
            mesurments.Add(timer.ElapsedTicks);
        }
        mesurments.CalcAvgAndDeviation(out average, out ds);
    }

    public static void SpeedTestNewtonsoft(
        IReadOnlyCollection<TargetObject> targetObjects,
        out double average, out double ds, int count = TesterNames.StatsTimes)
    {
        List<long> mesurments = new();
        var jsSerializer = new Newtonsoft.Json.JsonSerializer();
        for (int i = 0; i < count; ++i)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using JsonWriter jw = new JsonTextWriter(sw);
            timer.Reset();
            timer.Restart();
            jsSerializer.SerializerNwtonsoftDel(jw, targetObjects);
            timer.Stop();
            jw.Flush();
            mesurments.Add(timer.ElapsedTicks);

        }
        mesurments.CalcAvgAndDeviation(out average, out ds);
    }

    public static void SpeedTestNewSimpleSerialization(
        IReadOnlyCollection<TargetObject> targetObjects,
        out double average, out double ds, int count = TesterNames.StatsTimes)
    {
        List<long> mesurments = new();
        for (int i = 0; i < count; ++i)
        {
            timer.Reset();
            timer.Restart();
            var serialized = System.Text.Json.JsonSerializer.Serialize(targetObjects, TargetObjectSpeedUp.Default.IReadOnlyCollectionTargetObject);
            timer.Stop();
            mesurments.Add(timer.ElapsedTicks);
            File.WriteAllText("tempSer.txt", serialized);
        }
        mesurments.CalcAvgAndDeviation(out average, out ds);
    }


    public static void SerializerNewDel(Utf8JsonWriter writer, IReadOnlyCollection<TargetObject> targetObjects)
        => 
        Pipeline.Pipe(
            TargetObjectSpeedUp.Default?.IReadOnlyCollectionTargetObject?.SerializeHandler ?? throw new ArgumentNullException("Serialise"))
        .Invoke(writer, targetObjects);

    public static void SerializerOldDel(Utf8JsonWriter writer, IReadOnlyCollection<TargetObject> targetObjects)
        => System.Text.Json.JsonSerializer.Serialize(writer, targetObjects);

    public static void SerializerNwtonsoftDel(this Newtonsoft.Json.JsonSerializer nsSerializer, 
        JsonWriter writer, IReadOnlyCollection<TargetObject> targetObjects)
        => nsSerializer.Serialize(writer, targetObjects);
    

    public static string BuildTestResult(double oldStat, double newStat)
        =>
        new StringBuilder()
        .Append("Old serializer. Avergage ticks: ")
        .Append(Math.Round(oldStat, 2))
        .Append('\n')
        .Append("New serializer. Avergage ticks: ")
        .Append(Math.Round(newStat, 2))
        .Append('\n')
        .ToString();

    public static DataRow CalcRatios(this DataTable dt)
    {
        var avgRatio1 = dt
            .AsEnumerable()
            .Select(row => double.Parse(row[9].ToString() ?? throw new ArgumentNullException(nameof(dt))))
            .Sum() / dt.Rows.Count;

        var avgRatio2 = dt
            .AsEnumerable()
            .Select(row => double.Parse(row[10].ToString() ?? throw new ArgumentNullException(nameof(dt))))
            .Sum() / dt.Rows.Count;

        var avgRatio3 = dt
            .AsEnumerable()
            .Select(row => double.Parse(row[11].ToString() ?? throw new ArgumentNullException(nameof(dt))))
            .Sum() / dt.Rows.Count;
        var dr = dt.NewRow();
        dr[0] = dr[1] = dr[2] = dr[3] = dr[4] = dr[5] = dr[6] = dr[7] = '-';
        dr[8] = "Avg ratios";
        dr[9] = Math.Round(avgRatio1, TesterNames.RatioDigitsAfterDot);
        dr[10] = Math.Round(avgRatio2, TesterNames.RatioDigitsAfterDot);
        dr[11] = Math.Round(avgRatio3, TesterNames.RatioDigitsAfterDot);
        return dr;
    }

    private static void CalcAvgAndDeviation(this List<long> mesurments, out double avg, out double dev)
    {
        avg = mesurments.Sum();
        double average = avg;
        dev = Math.Sqrt(mesurments.Select(x => (x - average) * (x - average)).Sum() / (average - 1));
    }
}

