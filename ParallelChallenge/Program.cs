using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class Program
	{
		private static IContainer container;
		static void Main(string[] args)
		{
			string word = String.Empty;
			RegistDependencies();
			try
			{
				word = System.IO.File.ReadAllText(@"C:\Users\msogamoso\Documents\big.txt");
			}
			catch (Exception e)
			{
				Console.WriteLine(@"Exception: {0}", e.Message);
			}
			using (var scope = container.BeginLifetimeScope())
			{
				var messaging = scope.Resolve<IMessaging>();
				var forWithConcurrency = scope.Resolve<ForWithConcurrentQueue>();
				var forWithList = scope.Resolve<ForWithList>();
				var linqWithList = scope.Resolve<LinqWithList>();
				var linqWithConcurrency = scope.Resolve<LinqWithConcurrentQueue>();
				var taskWithConcurrency = scope.Resolve<TaskWithConcurrentQueue>();
				var taskWithList = scope.Resolve<TaskWithList>();
				var sequential = scope.Resolve<Sequential>();

			List<ParallelImplementation> parallels = new List<ParallelImplementation>
			{
				sequential,
				forWithConcurrency,
				forWithList,
				linqWithList,
				linqWithConcurrency,
				taskWithList,
				taskWithConcurrency
			};

				foreach (var item in parallels)
				{
					var watch = System.Diagnostics.Stopwatch.StartNew();
					item.ReturnWord("ewkjf358rtgue08ghingdhwek");
					Console.WriteLine(@"{0} Run", item.ToString());
					watch.Stop();
					Console.WriteLine(watch.ElapsedMilliseconds);
				}
			}
			//Console.WriteLine("Write Word to be procesed");
			//string word = Console.ReadLine();
		}

		private static void RegistDependencies()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ParallelImplementation>().As<IParallelImplementation>();
			builder.RegisterType<Messaging>().As<IMessaging>();
			builder.RegisterType<ForWithConcurrentQueue>();
			builder.RegisterType<LinqWithConcurrentQueue>();
			builder.RegisterType<LinqWithList>();
			builder.RegisterType<TaskWithConcurrentQueue>();
			builder.RegisterType<ForWithList>();
			builder.RegisterType<Sequential>();
			builder.RegisterType<TaskWithList>();

			container = builder.Build();
		}
	}
}
