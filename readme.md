# ![](https://github.com/kzu/funq/raw/main/assets/img/32x32.png) Funq

A fast DI container you can understand

## Overview

I created this DI container originally for use in Microsoft patterns & practices 
framework for developing mobile apps targeting the .NET Compact Framework, which 
had to run on very constrained devices (back then). No usage of System.Reflection 
was pretty much a given requirement.

Along the way, I created a [series of videos](https://www.youtube.com/playlist?list=PLpBzqAJhzCLfPHtdcPEy1jj3W16MAeX1M) 
where I showcasehow to use TDD to implement the whole thing from scratch.

## Performance

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3593/23H2/2023Update/SunValley3)
Intel Core i9-10900T CPU 1.90GHz, 1 CPU, 20 logical and 10 physical cores
  [Host]   : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256
  .NET 6.0 : .NET 6.0.27 (6.0.2724.6912), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
```

### Speed

| Method            | Runtime  | Mean            | Error          | StdDev         | Median          | Ratio     | RatioSD  |
|------------------ |--------- |----------------:|---------------:|---------------:|----------------:|----------:|---------:|
| 'No DI'           | .NET 6.0 |        85.90 ns |       1.755 ns |       4.204 ns |        85.48 ns |      1.00 |     0.00 |
| Funq              | .NET 6.0 |     1,279.53 ns |      22.287 ns |      20.848 ns |     1,275.61 ns |     14.51 |     0.71 |
| ServiceCollection | .NET 6.0 |    19,293.83 ns |     639.905 ns |   1,876.731 ns |    19,363.75 ns |    228.75 |    22.79 |
| Unity             | .NET 6.0 |    11,052.90 ns |     219.512 ns |     205.332 ns |    11,036.42 ns |    125.38 |     7.45 |
| Autofac           | .NET 6.0 |    52,322.62 ns |   1,044.219 ns |   2,714.063 ns |    51,397.70 ns |    611.19 |    40.38 |
| StructureMap      | .NET 6.0 | 4,106,653.85 ns | 109,422.178 ns | 313,952.741 ns | 4,050,650.00 ns | 47,554.83 | 3,709.43 |
| Ninject           | .NET 6.0 |   621,417.49 ns |  19,670.749 ns |  57,690.901 ns |   606,653.52 ns |  7,144.12 |   582.38 |
| Windsor           | .NET 6.0 |   165,673.09 ns |   2,802.828 ns |   2,484.634 ns |   165,504.05 ns |  1,873.34 |   103.36 |
|                   |          |                 |                |                |                 |           |          |
| 'No DI'           | .NET 8.0 |        63.21 ns |       1.249 ns |       1.624 ns |        63.16 ns |      1.00 |     0.00 |
| Funq              | .NET 8.0 |       843.21 ns |      16.439 ns |      16.145 ns |       839.61 ns |     13.29 |     0.46 |
| ServiceCollection | .NET 8.0 |     7,972.33 ns |     163.442 ns |     474.174 ns |     7,877.49 ns |    121.48 |     6.46 |
| Unity             | .NET 8.0 |     8,793.95 ns |     173.747 ns |     206.833 ns |     8,814.48 ns |    139.12 |     5.15 |
| Autofac           | .NET 8.0 |    40,158.30 ns |     793.924 ns |   1,004.059 ns |    40,017.48 ns |    635.76 |    23.40 |
| StructureMap      | .NET 8.0 | 3,007,362.81 ns |  51,683.220 ns |  48,344.516 ns | 3,022,072.27 ns | 47,453.44 | 1,330.72 |
| Ninject           | .NET 8.0 |   570,046.30 ns |  15,811.656 ns |  45,111.545 ns |   565,521.73 ns |  8,383.15 |   638.32 |
| Windsor           | .NET 8.0 |   140,258.83 ns |   2,799.971 ns |   7,988.474 ns |   137,446.48 ns |  2,183.18 |   114.48 |


### Allocations

| Method            | Runtime  | Gen0    | Gen1    | Allocated | Alloc Ratio |
|------------------ |--------- |--------:|--------:|----------:|------------:|
| 'No DI'           | .NET 6.0 |  0.0397 |       - |     416 B |        1.00 |
| Funq              | .NET 6.0 |  0.2155 |       - |    2256 B |        5.42 |
| ServiceCollection | .NET 6.0 |  1.3733 |  0.6714 |   14432 B |       34.69 |
| Unity             | .NET 6.0 |  1.7853 |  0.0610 |   18696 B |       44.94 |
| Autofac           | .NET 6.0 |  3.2959 |  1.6479 |   34859 B |       83.80 |
| StructureMap      | .NET 6.0 | 23.4375 |  7.8125 |  294826 B |      708.72 |
| Ninject           | .NET 6.0 |  7.8125 |  2.9297 |   88347 B |      212.37 |
| Windsor           | .NET 6.0 | 11.9629 |  0.7324 |  125665 B |      302.08 |
|                   |          |         |         |           |             |
| 'No DI'           | .NET 8.0 |  0.0397 |       - |     416 B |        1.00 |
| Funq              | .NET 8.0 |  0.2155 |  0.0010 |    2256 B |        5.42 |
| ServiceCollection | .NET 8.0 |  1.1597 |  1.0986 |   12335 B |       29.65 |
| Unity             | .NET 8.0 |  1.7853 |  0.0610 |   18696 B |       44.94 |
| Autofac           | .NET 8.0 |  2.9297 |  2.6855 |   32745 B |       78.71 |
| StructureMap      | .NET 8.0 | 23.4375 | 19.5313 |  281557 B |      676.82 |
| Ninject           | .NET 8.0 |  8.7891 |  3.9063 |   93223 B |      224.09 |
| Windsor           | .NET 8.0 | 11.7188 |  0.9766 |  125664 B |      302.08 |
