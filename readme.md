# ![](https://github.com/kzu/funq/raw/main/assets/img/32x32.png) Funq

A fast DI container you can understand

## Performance

```
BenchmarkDotNet v0.13.8, Windows 11 (10.0.22622.575)
Intel Core i9-10900T CPU 1.90GHz, 1 CPU, 20 logical and 10 physical cores
  [Host]   : .NET Framework 4.8.1 (4.8.9167.0), X64 RyuJIT VectorSize=256
  .NET 6.0 : .NET 6.0.20 (6.0.2023.32017), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.0 (8.0.23.37506), X64 RyuJIT AVX2
```

### Speed

| Method       | Runtime    | Mean         | Error      | StdDev       | Median       | Ratio  | RatioSD |
|------------- |----------- |-------------:|-----------:|-------------:|-------------:|-------:|--------:|
| 'No DI'      | .NET 6.0   |     73.62 ns |   2.131 ns |     6.010 ns |     72.24 ns |   1.00 |    0.00 |
| Funq         | .NET 6.0   |    661.17 ns |  12.855 ns |    13.201 ns |    659.32 ns |   8.54 |    0.86 |
| Unity        | .NET 6.0   |  1,945.63 ns |  37.307 ns |    51.066 ns |  1,929.66 ns |  25.79 |    2.17 |
| Autofac      | .NET 6.0   |  5,863.56 ns | 116.573 ns |   258.317 ns |  5,830.97 ns |  81.33 |    7.63 |
| StructureMap | .NET 6.0   |  2,551.67 ns |  50.061 ns |    92.791 ns |  2,510.96 ns |  35.10 |    2.91 |
| Ninject      | .NET 6.0   | 21,154.36 ns | 401.301 ns |   991.916 ns | 21,199.50 ns | 290.24 |   28.06 |
| Windsor      | .NET 6.0   | 11,387.67 ns | 222.796 ns |   418.466 ns | 11,228.28 ns | 156.81 |   11.51 |
|              |            |              |            |              |              |        |         |
| 'No DI'      | .NET 8.0   |     67.12 ns |   1.241 ns |     1.161 ns |     67.05 ns |   1.00 |    0.00 |
| Funq         | .NET 8.0   |    539.99 ns |  10.304 ns |    21.279 ns |    533.75 ns |   8.12 |    0.43 |
| Unity        | .NET 8.0   |  1,429.12 ns |  23.856 ns |    24.498 ns |  1,425.08 ns |  21.32 |    0.49 |
| Autofac      | .NET 8.0   |  4,085.07 ns |  81.079 ns |   221.953 ns |  4,014.93 ns |  62.77 |    3.82 |
| StructureMap | .NET 8.0   |  2,095.20 ns |  40.860 ns |   110.467 ns |  2,088.39 ns |  31.13 |    1.81 |
| Ninject      | .NET 8.0   | 17,282.94 ns | 435.455 ns | 1,235.313 ns | 17,176.51 ns | 265.10 |   19.16 |
| Windsor      | .NET 8.0   |  8,256.84 ns | 142.181 ns |   139.641 ns |  8,220.55 ns | 123.14 |    3.05 |

### Allocations

| Method       | Runtime    | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------------- |----------- |-------:|-------:|----------:|------------:|
| 'No DI'      | .NET 6.0   | 0.0374 |      - |     392 B |        1.00 |
| Funq         | .NET 6.0   | 0.0906 |      - |     952 B |        2.43 |
| Unity        | .NET 6.0   | 0.2060 |      - |    2176 B |        5.55 |
| Autofac      | .NET 6.0   | 0.4654 |      - |    4904 B |       12.51 |
| StructureMap | .NET 6.0   | 0.2975 |      - |    3120 B |        7.96 |
| Ninject      | .NET 6.0   | 1.4954 | 0.3662 |   15736 B |       40.14 |
| Windsor      | .NET 6.0   | 0.9155 |      - |    9712 B |       24.78 |
|              |            |        |        |           |             |
| 'No DI'      | .NET 8.0   | 0.0374 |      - |     392 B |        1.00 |
| Funq         | .NET 8.0   | 0.0906 |      - |     952 B |        2.43 |
| Unity        | .NET 8.0   | 0.2079 |      - |    2176 B |        5.55 |
| Autofac      | .NET 8.0   | 0.4654 |      - |    4904 B |       12.51 |
| StructureMap | .NET 8.0   | 0.2975 |      - |    3120 B |        7.96 |
| Ninject      | .NET 8.0   | 1.3428 | 0.3357 |   14096 B |       35.96 |
| Windsor      | .NET 8.0   | 0.9155 |      - |    9712 B |       24.78 |