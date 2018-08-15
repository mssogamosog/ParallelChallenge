using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class LinqWithConcurrentQueue : ParallelImplementation
	{
		public LinqWithConcurrentQueue(IMessaging messaging, IGetValue getValue) : base(messaging, getValue)
		{
		}

		public override void ReturnWord(string word)
		{
			ConcurrentQueue<string> wordSplited = new ConcurrentQueue<string>();
			word.Select(c => c.ToString()).ToList().ForEach(letter => wordSplited.Enqueue(letter));
			if (word.Length <= int.MaxValue)
			{
				wordSplited.AsParallel().WithDegreeOfParallelism(20).ForAll((character) =>
				{
					wordSplited.TryDequeue(out character);
					_getValue.Get(character);
				}
				);
			}
			else
			{
				_messaging.InvalidWord();
			}

		}
	}
}
