using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class TaskWithList : ParallelImplementation
	{
		public override void ReturnWord(string word)
		{
			var count = 20;
			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			Task[] tasks = new Task[count];
			var e = wordSplited.GetEnumerator();
			try
			{
				if (word.Length <= int.MaxValue)
				{
					for (int i = 0; i < count; i++)
					{
						tasks[i] = new Task(() =>
						{
							while (e.MoveNext())
							{
								string character = e.Current;
								if(character != null)
								{
									GetValue(character);
								}
							}
						});
					}
					foreach (var task in tasks)
					{
						task.Start();
					}

					Task.WaitAll(tasks);

				}
				else
				{
					Console.WriteLine("The Word must have less than 20 characters");
				}
			}
			catch (AggregateException ex)
			{

				Console.WriteLine("ReturnWordWithTaskConcurrentQueue :" + ex.Message);
				foreach (var e1 in ex.InnerExceptions)
				{
					// Handle the custom exception.
					Console.WriteLine("ReturnWordWithTaskConcurrentQueue :" + e1.Message);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ReturnWordWithTaskConcurrentQueue :" + ex.Message);
			}


		}
	}
}
