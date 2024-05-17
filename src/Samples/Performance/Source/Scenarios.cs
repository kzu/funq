using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Performance
{
    [MemoryDiagnoser]
    [MarkdownExporter]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class Scenarios
    {
        [Benchmark(Baseline = true, Description = "No DI")]
        public void PlainUseCase() => new PlainUseCase().Run();

        [Benchmark(Description = "Funq")]
        public void FunqUseCase() => new FunqUseCase().Run();

        [Benchmark(Description = "ServiceCollection")]
        public void ServiceCollectionUseCase() => new ServiceCollectionUseCase().Run();

        [Benchmark(Description = "Unity")]
        public void UnityUseCase() => new UnityUseCase().Run();

        [Benchmark(Description = "Autofac")]
        public void AutofacUseCase() => new AutofacUseCase().Run();

        [Benchmark(Description = "StructureMap")]
        public void StructureMapUseCase() => new StructureMapUseCase().Run();

        [Benchmark(Description = "Ninject")]
        public void NinjectUseCase() => new NinjectUseCase().Run();

        [Benchmark(Description = "Windsor")]
        public void WindsorUseCase() => new WindsorUseCase().Run();
    }
}
