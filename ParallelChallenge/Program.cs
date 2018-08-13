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
				word = System.IO.File.ReadAllText(@"C:\Users\msogamoso\Documents\big2.txt");
			}
			catch (Exception e)
			{
				Console.WriteLine(@"Exception: {0}", e.Message);
			}

			Sequential sequential = new Sequential();
			ForWithList forWithList = new ForWithList();
			ForWithConcurrentQueue forWithConcurrentQueue = new ForWithConcurrentQueue();
			TaskWithList taskWithList = new TaskWithList();
			TaskWithConcurrentQueue taskWithConcurrentQueue = new TaskWithConcurrentQueue();
			LinqWithList linqWithList = new LinqWithList();
			LinqWithConcurrentQueue linqWithConcurrentQueue = new LinqWithConcurrentQueue();

			List < ParallelImplementation > parallels = new List<ParallelImplementation>
			{
				sequential, forWithList , forWithConcurrentQueue,taskWithList,
				taskWithConcurrentQueue,linqWithList,linqWithConcurrentQueue
			};
			foreach (var item in parallels)
			{
				var watch = System.Diagnostics.Stopwatch.StartNew();
				item.ReturnWord(word);
				Console.WriteLine(@"{0} Run", item.GetType().ToString());
				watch.Stop();
				Console.WriteLine(watch.ElapsedMilliseconds);
			}
			//Console.WriteLine("Write Word to be procesed");
			//string word = Console.ReadLine();
		}
	}
}
