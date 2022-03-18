using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SmallSerializatorBenchmarker
{
    private static readonly Serializator serializator;

    private static readonly Universe smallObject;

    static SmallSerializatorBenchmarker()
    {
        serializator = new();
        smallObject = new()
        {
            Stars = new Star[]
            {
                new()
                {
                    Name = "Saturn",
                    LongName = "Saturn",
                    Mass = 95.16M,
                    SatelliteNumber = 82,
                    OtherProperties = new string[] {"a", "asda", "Asdasdasd"}
                },
                new()
                {
                    Name = "Jupiter",
                    LongName = "Jupiter is big",
                    Mass = 317.8M,
                    SatelliteNumber = 79,
                    OtherProperties = new string[] {"ss", "s", "Asdasdasd", "strings"}
                }
            }
        };
    }

    [Benchmark]
    public void SmallNS()
        => serializator.SerializeNS(smallObject);

    [Benchmark]
    public void Small()
        => serializator.Serialize(smallObject);

    [Benchmark]
    public void SmallCG()
        => serializator.SerializeFaster(smallObject);

    // [Benchmark]
    // public void Utf8SerializeAnObject()
    //     => serializator.Utf8Serialize(ObjectInstances.targetObjects);

    // [Benchmark]
    // public void Utf8SerializeAHugeAnObject()
    //     => serializator.Utf8Serialize(ObjectInstances.hugeTargetObject);

    // [Benchmark]
    // public void Utf8SerializeAnObjectFaster()
    //     => serializator.Utf8Serialize(ObjectInstances.targetObjects);

    // [Benchmark]
    // public void Utf8SerializeAHugeAnObjectFaster()
    //     => serializator.Utf8Serialize(ObjectInstances.hugeTargetObject);
}