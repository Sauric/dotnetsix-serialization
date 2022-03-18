using DataTablePrettyPrinter;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonSerialization;

delegate void Serializer(Utf8JsonWriter writer, IReadOnlyCollection<TargetObject> targetObjects); 
class  Program
{
    private static DataTable Table;

    static Program()
    {
        Table = new(".NET 6 serializer speed test");
        Table.Columns.AddRange(new DataColumn[]
            {
                new("Test num."),
                new("Reflection"),
                new("dS1"),
                new("Newtonsoft"),
                new("dS2"),
                new("CodeGeneration"),
                new("dS3"),
                new("CodeGenerationS"),
                new("dS4"),
                new("Ratio(ref/codGen)"),
                new("Ratio(nst/codGen)"),
                new("Ratio(codGenS/codGen)")

            });
    }
    public static void Main(string[] args)
    {
        DataTable rawTable = Table.Clone();
        for (int i = 0; i < TesterNames.Attempts; ++i)
        {
            var bigObject = SpeedTestHelper.MakeBigObject();

            SpeedTestHelper.SpeedTest(SpeedTestHelper.SerializerOldDel, bigObject, out var avgOld, out var dsOld);
            SpeedTestHelper.SpeedTest(SpeedTestHelper.SerializerNewDel, bigObject, out var avgNew, out var dsNew);
            SpeedTestHelper.SpeedTestNewtonsoft(bigObject, out var avgNst, out var dsNst);
            SpeedTestHelper.SpeedTestNewSimpleSerialization( bigObject, out var avgNewS, out var dsNewS);
            var rowArr = new object[]
                {
                    $"#{i + 1,-2}",
                    Math.Round(avgOld, TesterNames.DigitsAfterDot),
                    Math.Round(dsOld, TesterNames.DigitsAfterDot),
                    Math.Round(avgNst, TesterNames.DigitsAfterDot),
                    Math.Round(dsNst, TesterNames.DigitsAfterDot),
                    Math.Round(avgNew, TesterNames.DigitsAfterDot),
                    Math.Round(dsNew, TesterNames.DigitsAfterDot),
                    Math.Round(avgNewS, TesterNames.DigitsAfterDot),
                    Math.Round(dsNewS, TesterNames.DigitsAfterDot),
                    Math.Round(avgOld / avgNew, TesterNames.RatioDigitsAfterDot),
                    Math.Round(avgNst / avgNew, TesterNames.RatioDigitsAfterDot),
                    Math.Round(avgNewS / avgNew, TesterNames.RatioDigitsAfterDot)
                };

            rawTable.Rows.Add(rowArr);

            if (dsOld > avgOld || dsNew > avgNew)
            {
                i--;
                continue;
            }
            Table.Rows.Add(rowArr);
            Console.WriteLine($"Old: {rowArr[1], -10} Nst: {rowArr[3],-10} New: {rowArr[5],-10} New New: {Math.Round(avgNewS, TesterNames.DigitsAfterDot)}");
        }

        Table.Rows.Add(Table.CalcRatios());

        Console.WriteLine();
        Console.WriteLine(Table.ToPrettyPrintedString());
        File.WriteAllText("SpeedTest.txt", Table.ToPrettyPrintedString(), Encoding.UTF8);
        rawTable.Rows.Add(rawTable.CalcRatios());
        for(int i = 0; i < rawTable.Rows.Count; ++i)
        {
            rawTable.Rows[i][0] = $"#{i + 1,-2}";
        }
        File.WriteAllText("SpeedTestRaw.txt", rawTable.ToPrettyPrintedString(), Encoding.UTF8);
        Console.ReadKey();
    }

    
}
