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
			IMessaging messaging = new Messaging();

			List < ParallelImplementation > parallels = new List<ParallelImplementation>
			{
				new LinqWithConcurrentQueue(messaging),
				new LinqWithList(messaging),
				new TaskWithConcurrentQueue(messaging),
				new TaskWithList(messaging),
				new ForWithConcurrentQueue(messaging),
				new ForWithList(messaging),
				new Sequential(messaging)
			};
			foreach (var item in parallels)
			{
				var watch = System.Diagnostics.Stopwatch.StartNew();
				item.ReturnWord(word);
				Console.WriteLine(@"{0} Run", item.ToString());
				watch.Stop();
				Console.WriteLine(watch.ElapsedMilliseconds);
			}
			//Console.WriteLine("Write Word to be procesed");
			//string word = Console.ReadLine();
		}
	}
}
