using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	public class Sequential : ParallelImplementation
	{
		public Sequential(IMessaging messaging) : base(messaging)
		{
		}

		public override void ReturnWord(string word)
		{
			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			if (word.Length <= int.MaxValue)
			{
				foreach (var character in wordSplited)
				{
					GetValue(character);
				}
			}
			else
			{
				_messaging.InvalidWord();
			}

		}
	}
}
