using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class ForWithList: ParallelImplementation
	{
		public ForWithList(IMessaging messaging) : base(messaging)
		{
		}

		public override void ReturnWord(string word)
		{
			var option = new ParallelOptions { MaxDegreeOfParallelism = 20 };
			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			if (word.Length <= int.MaxValue)
			{
				Parallel.ForEach(wordSplited, character =>
				{
					GetValue(character);
				});
			}
			else
			{
				_messaging.InvalidWord();
			}

		}
	}
}
