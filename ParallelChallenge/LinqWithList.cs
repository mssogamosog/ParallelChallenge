﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class LinqWithList : ParallelImplementation
	{
		public LinqWithList(IMessaging messaging, IGetValue getValue) : base(messaging, getValue)
		{
		}

		public override void ReturnWord(string word)
		{
			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			if (word.Length <= int.MaxValue)
			{
				wordSplited.AsParallel().WithDegreeOfParallelism(20).ForAll((character) =>
				{
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
