using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class TaskWithConcurrentQueue : ParallelImplementation
	{
		public override void ReturnWord(string word)
		{
			var count = 20;
			ConcurrentQueue<string> wordSplited = new ConcurrentQueue<string>();
			word.Select(c => c.ToString()).ToList().ForEach(letter => wordSplited.Enqueue(letter));
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
							while (wordSplited.Count() > 0)
							{
								wordSplited.TryDequeue(out string character);
								if (character != null)
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
