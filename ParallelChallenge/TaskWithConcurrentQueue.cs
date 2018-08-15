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
		public TaskWithConcurrentQueue(IMessaging messaging, IGetValue getValue) : base(messaging, getValue)
		{
		}

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
								if (wordSplited.TryDequeue(out string character))
								{
									_getValue.Get(character);
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
					_messaging.InvalidWord();
				}
			}
			catch (AggregateException ex)
			{

				_messaging.Exception(ex);
				foreach (var e1 in ex.InnerExceptions)
				{
					_messaging.Exception(e1);
				}
			}
			catch (Exception ex)
			{
				_messaging.Exception(ex);
			}


		}
	}
}
