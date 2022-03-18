using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class TinySerializatorBenchmarker
{
    private static readonly Serializator serializator;

    private static readonly Universe tinyObject;

    static TinySerializatorBenchmarker()
    {
        serializator = new();
        tinyObject = new()
        {
            Stars = new Star[]
            {
                new()
                {
                    Name = "Saturn",
                    LongName = "Saturn is bad",
                    Mass = 95.16M,
                    SatelliteNumber = 82,
                    OtherProperties = new string[] {"a", "asda", "Asdasdasd"}
                }
            }
        };
    }

    [Benchmark]
    public void TinyNS()
        => serializator.SerializeNS(tinyObject);

    [Benchmark]
    public void Tiny()
        => serializator.Serialize(tinyObject);

    [Benchmark]
    public void TinyCG()
        => serializator.SerializeFaster(tinyObject);
}