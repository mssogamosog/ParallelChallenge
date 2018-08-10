using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			string word = String.Empty;
			try
			{
				word = System.IO.File.ReadAllText(@"C:\Users\msogamoso\Documents\big.txt");
			}
			catch (Exception e)
			{

				Console.WriteLine(@"Exception {0}", e.Message);
			}
			ParallelImplementation p = new ParallelImplementation();
			Console.WriteLine("Write Word to be procesed");
			//string word = Console.ReadLine();
			var watch = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWord(word);
			Console.WriteLine("Sequential Run");
			watch.Stop();
			Console.WriteLine(watch.ElapsedMilliseconds);

			var watch2 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordParallelWithConcurrentQueue(word);
			Console.WriteLine("Parallel With Concurrent Queue");
			watch2.Stop();
			Console.WriteLine(watch2.ElapsedMilliseconds);

			var watch3 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordParallelWithList(word);
			Console.WriteLine("Parallel with List");
			watch3.Stop();
			Console.WriteLine(watch3.ElapsedMilliseconds);
			

		}
	}
}
