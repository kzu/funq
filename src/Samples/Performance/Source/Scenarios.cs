using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Performance
{
    public class Scenarios
    {
        static readonly List<UseCaseInfo> useCases = new()
        {
            new PlainUseCase(),
            new FunqUseCase(),
            new UnityUseCase(),
            new AutofacUseCase(),
            new StructureMapUseCase(),
            new NinjectUseCase(),
            new WindsorUseCase(), 
		};

        [Benchmark(Description = "No DI")]
        public void PlainUseCase() => useCases[0].UseCase.Run();

        [Benchmark(Description = "Funq")]
        public void FunqUseCase() => useCases[1].UseCase.Run();

        [Benchmark(Description = "Unity")]
        public void UnityUseCase() => useCases[2].UseCase.Run();

        [Benchmark(Description = "Autofac")]
        public void AutofacUseCase() => useCases[3].UseCase.Run();

        [Benchmark(Description = "StructureMap")]
        public void StructureMapUseCase() => useCases[4].UseCase.Run();

        [Benchmark(Description = "Ninject")]
        public void NinjectUseCase() => useCases[5].UseCase.Run();

        [Benchmark(Description = "Windsor")]
        public void WindsorUseCase() => useCases[6].UseCase.Run();
    }
}
