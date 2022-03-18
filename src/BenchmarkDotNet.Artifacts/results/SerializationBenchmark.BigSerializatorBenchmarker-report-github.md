``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22567
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
| Method |     Mean |   Error |   StdDev | Rank |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|------- |---------:|--------:|---------:|-----:|--------:|--------:|--------:|----------:|
|    Big | 121.6 μs | 4.00 μs | 11.80 μs |    1 | 39.1846 | 38.2080 | 38.2080 |    132 KB |
|  BigCG | 146.0 μs | 3.13 μs |  9.19 μs |    2 | 37.5977 | 36.8652 | 36.8652 |    132 KB |
|  BigNS | 217.9 μs | 8.64 μs | 25.21 μs |    3 | 99.3652 | 57.8613 | 37.1094 |    277 KB |
