``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22567
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
| Method |     Mean |     Error |    StdDev | Rank |  Gen 0 | Allocated |
|------- |---------:|----------:|----------:|-----:|-------:|----------:|
|   Tiny | 1.679 μs | 0.0117 μs | 0.0098 μs |    1 | 0.4082 |     856 B |
| TinyCG | 1.687 μs | 0.0097 μs | 0.0086 μs |    1 | 0.4082 |     856 B |
| TinyNS | 4.221 μs | 0.0666 μs | 0.0556 μs |    2 | 1.5869 |   3,320 B |
