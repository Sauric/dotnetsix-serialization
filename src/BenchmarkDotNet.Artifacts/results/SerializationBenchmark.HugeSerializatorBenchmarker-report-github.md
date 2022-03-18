``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22567
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
| Method |       Mean |    Error |   StdDev | Rank |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------- |-----------:|---------:|---------:|-----:|---------:|---------:|---------:|----------:|
| HugeCG |   691.9 μs | 39.80 μs | 117.3 μs |    1 | 143.5547 | 141.6016 | 141.6016 |    515 KB |
|   Huge |   711.4 μs | 55.29 μs | 157.8 μs |    1 | 142.5781 | 140.6250 | 140.6250 |    516 KB |
| HugeNS | 1,332.3 μs | 44.69 μs | 131.8 μs |    2 | 260.7422 | 219.7266 | 142.5781 |  1,040 KB |
