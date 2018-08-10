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
			Console.WriteLine("Parallel For With Concurrent Queue");
			watch2.Stop();
			Console.WriteLine(watch2.ElapsedMilliseconds);

			var watch3 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordParallelWithList(word);
			Console.WriteLine("Parallel For with List");
			watch3.Stop();
			Console.WriteLine(watch3.ElapsedMilliseconds);

			var watch4 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordWithTask(word);
			Console.WriteLine("Parallel with ReturnWordWithTask");
			watch4.Stop();
			Console.WriteLine(watch4.ElapsedMilliseconds);

			var watch5 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordWithTaskConcurrentQueue(word);
			Console.WriteLine("Parallel with ReturnWordWithTaskConcurrentQueue");
			watch5.Stop();
			Console.WriteLine(watch5.ElapsedMilliseconds);

			var watch6 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordAsParallel(word);
			Console.WriteLine("Parallel with As Parallel");
			watch6.Stop();
			Console.WriteLine(watch6.ElapsedMilliseconds);

			var watch7 = System.Diagnostics.Stopwatch.StartNew();
			p.ReturnWordAsParallelConcurrentQueue(word);
			Console.WriteLine("Parallel with As Parallel Concurrent Queue");
			watch7.Stop();
			Console.WriteLine(watch7.ElapsedMilliseconds);

		}
	}
}
