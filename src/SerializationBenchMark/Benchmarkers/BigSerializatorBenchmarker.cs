using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BigSerializatorBenchmarker
{
    private static readonly Serializator serializator;

    private static readonly Universe bigObject;

    static BigSerializatorBenchmarker()
    {
        serializator = new();
        bigObject = Objects.GenerateHugeTargetObject(Objects.GenerateStringArray(25), 25);
    }

    [Benchmark]
    public void BigNS()
        => serializator.SerializeNS(bigObject);

    [Benchmark]
    public void Big()
        => serializator.Serialize(bigObject);

    [Benchmark]
    public void BigCG()
        => serializator.SerializeFaster(bigObject);
}