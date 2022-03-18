``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22567
Unknown processor
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
| Method |       Mean |    Error |   StdDev | Rank |  Gen 0 | Allocated |
|------- |-----------:|---------:|---------:|-----:|-------:|----------:|
| TinyCG |   512.8 ns |  6.79 ns |  6.02 ns |    1 | 0.2403 |     504 B |
|   Tiny | 1,026.6 ns | 16.41 ns | 14.55 ns |    2 | 0.4044 |     848 B |
| TinyNS | 2,190.8 ns | 43.24 ns | 57.73 ns |    3 | 0.8965 |   1,880 B |
