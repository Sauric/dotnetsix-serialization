using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using BenchmarkDotNet.Running;

namespace SerializationBenchmark;

class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<TinySerializatorBenchmarker>();
        BenchmarkRunner.Run<SmallSerializatorBenchmarker>();
        BenchmarkRunner.Run<BigSerializatorBenchmarker>();
        BenchmarkRunner.Run<HugeSerializatorBenchmarker>();
        BenchmarkRunner.Run<GlobalSerializatorBenchmarker>();
        BenchmarkRunner.Run<DeserializatorBenchmarker>();

    }
}