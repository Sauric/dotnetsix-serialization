using BenchmarkDotNet.Attributes;

namespace SerializationBenchmark;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class GlobalSerializatorBenchmarker
{
    private static readonly Serializator serializator;

    static GlobalSerializatorBenchmarker()
        =>
        serializator = new();

    #region Tiny
    [Benchmark]
    public void TinyNS()
        => serializator.SerializeNS(Objects.tinyObject);

    [Benchmark]
    public void Tiny()
        => serializator.Serialize(Objects.tinyObject);

    [Benchmark]
    public void TinyCG()
        => serializator.SerializeFaster(Objects.tinyObject);

    [Benchmark]
    public void TinyM()
        => serializator.SerializeM(Objects.tinyObject);
    #endregion

    #region Small
    [Benchmark]
    public void SmallNS()
        => serializator.SerializeNS(Objects.smallObject);

    [Benchmark]
    public void Small()
        => serializator.Serialize(Objects.smallObject);

    [Benchmark]
    public void SmallCG()
        => serializator.SerializeFaster(Objects.smallObject);

    [Benchmark]
    public void SmallM()
        => serializator.SerializeM(Objects.smallObject);
    #endregion

    #region Big
    [Benchmark]
    public void BigNS()
        => serializator.SerializeNS(Objects.bigObject);

    [Benchmark]
    public void Big()
        => serializator.Serialize(Objects.bigObject);

    [Benchmark]
    public void BigCG()
        => serializator.SerializeFaster(Objects.bigObject);

    [Benchmark]
    public void BigM()
        => serializator.SerializeM(Objects.bigObject);
    #endregion

    #region Huge
    [Benchmark]
    public void HugeNS()
        => serializator.SerializeNS(Objects.hugeObject);

    [Benchmark]
    public void Huge()
        => serializator.Serialize(Objects.hugeObject);

    [Benchmark]
    public void HugeCG()
        => serializator.SerializeFaster(Objects.hugeObject);
    [Benchmark]
    public void HugeM()
        => serializator.SerializeM(Objects.hugeObject);
    #endregion

    #region Utf8
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
    #endregion
}