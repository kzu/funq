using System;
using System.Diagnostics;
using System.IO;

namespace Performance
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("usage: {0} numerOfIterations", 
					Path.GetFileName(typeof(Program).Assembly.ManifestModule.FullyQualifiedName));

				return;
			}

			int iterations = int.Parse(args[0]);
			Console.WriteLine("Running {0} iterations for each use case.", args[0]);

			int padding = 50;
			UseCase uc = new PlainUseCase();
			Console.WriteLine(Pad(padding, "Plain no-DI: {0}"), Measure(uc.Run, iterations));

			uc = new AutofacUseCase();
			Console.WriteLine(Pad(padding, "Autofac: {0}"), Measure(uc.Run, iterations));

			uc = new NinjectUseCase();
			Console.WriteLine(Pad(padding, "Ninject: {0}"), Measure(uc.Run, iterations));

			uc = new StructureMapUseCase();
			Console.WriteLine(Pad(padding, "StructureMap: {0}"), Measure(uc.Run, iterations));

			uc = new UnityUseCase();
			Console.WriteLine(Pad(padding, "Unity: {0}"), Measure(uc.Run, iterations));

			uc = new FunqUseCase();
			Console.WriteLine(Pad(padding, "Funq: {0}"), Measure(uc.Run, iterations));
		}

		private static string Pad(int count, string value)
		{
			return value + new string(' ', count - value.Length);
		}

		private static long Measure(Action action, int iterations)
		{
			GC.Collect();
			var watch = Stopwatch.StartNew();

			for (int i = 0; i < iterations; i++)
			{
				action();
			}

			return watch.ElapsedTicks;
		}
	}
}
