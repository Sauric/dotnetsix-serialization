``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22567
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|  Method |       Mean |    Error |   StdDev | Rank |  Gen 0 | Allocated |
|-------- |-----------:|---------:|---------:|-----:|-------:|----------:|
| SmallCG |   808.6 ns |  2.64 ns |  2.20 ns |    1 | 0.3786 |     792 B |
|   Small | 1,626.7 ns |  9.96 ns |  8.32 ns |    2 | 0.5417 |   1,136 B |
| SmallNS | 3,435.6 ns | 17.42 ns | 14.54 ns |    3 | 1.3580 |   2,840 B |
