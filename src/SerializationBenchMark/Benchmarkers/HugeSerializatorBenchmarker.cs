using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class HugeSerializatorBenchmarker
{
    private static readonly Serializator serializator;

    private static readonly Universe hugeObject;
    
    static HugeSerializatorBenchmarker()
    {
        serializator = new();
        hugeObject = Objects.GenerateHugeTargetObject(Objects.GenerateStringArray(50), 50);
    }

    [Benchmark]
    public void HugeNS()
        => serializator.SerializeNS(hugeObject);

    [Benchmark]
    public void Huge()
        => serializator.Serialize(hugeObject);

    [Benchmark]
    public void HugeCG()
        => serializator.SerializeFaster(hugeObject);
}