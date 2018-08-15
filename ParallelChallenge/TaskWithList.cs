using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class TaskWithList : ParallelImplementation
	{
		public ICustomTaskManager _customManager;

		public TaskWithList(IMessaging messaging, IGetValue getValue, ICustomTaskManager customManager) : base(messaging, getValue)
		{
			_customManager = customManager;
		}

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
					_customManager.RunTask(wordSplited);
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
