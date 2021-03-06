﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class ForWithConcurrentQueue : ParallelImplementation
	{
		public ForWithConcurrentQueue(IMessaging messaging, IGetValue getValue) : base(messaging, getValue)
		{
		}

		public override void ReturnWord(string word)
		{
			var option = new ParallelOptions { MaxDegreeOfParallelism = 20 };
			ConcurrentQueue<string> wordSplited = new ConcurrentQueue<string>();
			word.Select(c => c.ToString()).ToList().ForEach(letter => wordSplited.Enqueue(letter));
			if (word.Length <= int.MaxValue)
			{
				Parallel.ForEach(wordSplited, character =>
				{
					_getValue.Get(character);
				});
			}
			else
			{
				_messaging.InvalidWord();
			}

		}
	}
}
