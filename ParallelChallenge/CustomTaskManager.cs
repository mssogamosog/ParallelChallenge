using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class CustomTaskManager : ICustomTaskManager
	{
		public IGetValue _getValue;

		public CustomTaskManager(IGetValue getValue)
		{
			_getValue = getValue;
		}

		public void RunTask(List<string> wordSplited)
		{
			var count = 20;
			Task[] tasks = new Task[count];
			var e = wordSplited.GetEnumerator();
			for (int i = 0; i < count; i++)
			{
				tasks[i] = new Task(() =>
				{
					while (e.MoveNext())
					{
						if (e.Current is string)
						{
							_getValue.Get(e.Current);
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
	}
}
