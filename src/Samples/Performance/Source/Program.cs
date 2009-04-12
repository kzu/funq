using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Performance
{
	class Program
	{
		const long DefaultIterations = 1000;
		static readonly List<long> BatchIterations = new List<long> { 1000, 5000, 20000, 100000, 250000, 1000000 };
		static readonly List<UseCaseInfo> useCases = new List<UseCaseInfo>
		{
			new PlainUseCase(),
			new FunqUseCase(), 
			new UnityUseCase(),
			new AutofacUseCase(), 
			new StructureMapUseCase(),
			new NinjectUseCase(), 
			new Ninject2UseCase(), 
			new WindsorUseCase(), 
			new MachineUseCase(),
		};

		static void Main(string[] args)
		{
			if (args.Length == 1 && args[0] == "csv")
				RunBatch();
			else
				RunInteractive(args);
		}

		private static void RunBatch()
		{
			Console.Write(";");
			useCases.ForEach(uc => Console.Write("{0};", uc.Name));
			Console.WriteLine();
			BatchIterations.ForEach(iterations =>
			{
				Console.Write("{0};", iterations);
				useCases.ForEach(uc =>
				{
					// warmup
					uc.UseCase.Run();
					GC.Collect();
					Console.Write("{0};", Measure(uc.UseCase.Run, iterations));
				});
				Console.WriteLine();
			});
		}

		private static void RunInteractive(string[] args)
		{
			long iterations = DefaultIterations;

			if (args.Length != 0)
				iterations = long.Parse(args[0]);

			Console.WriteLine("Running {0} iterations for each use case.", iterations);

			useCases.ForEach(uc =>
			{
				// warmup
				uc.UseCase.Run();
				GC.Collect();
				Console.WriteLine("{0}: {1}", uc.Name, Measure(uc.UseCase.Run, iterations));
			});
		}

		private static string Pad(int count, string value)
		{
			return value + new string(' ', count - value.Length);
		}

		private static decimal Measure(Action action, decimal iterations)
		{
			GC.Collect();
			var begin = Stopwatch.GetTimestamp();

			for (int i = 0; i < iterations; i++)
			{
				action();
			}

			var end = Stopwatch.GetTimestamp();

			return (decimal)(end - begin) / iterations;
		}
	}
}
