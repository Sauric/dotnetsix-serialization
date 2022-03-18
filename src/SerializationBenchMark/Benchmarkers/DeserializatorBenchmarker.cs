using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class DeserializatorBenchmarker
{
    private static Deserializator deserializator;

    static DeserializatorBenchmarker()
        => deserializator = new();

    [Benchmark]
    public void TinyNS()
        => deserializator.DeserializeNS(Objects.tinyObjectString);
    
    [Benchmark]
    public void Tiny()
        => deserializator.Deserialize(Objects.tinyObjectString);

    [Benchmark]
    public void TinyCG()
        => deserializator.DeserializeCG(Objects.tinyObjectString);
}