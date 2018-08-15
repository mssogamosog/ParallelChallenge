using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class GetValue : IGetValue
	{
		public IMessaging _messaging;

		public GetValue(IMessaging messaging)
		{
			_messaging = messaging;
		}

		public void Get(string character)
		{
			if (Constants.Words.TryGetValue(character.ToUpper(), out string value))
			{
				_messaging.ShowResult(character, value);
				//Thread.Sleep(1);
			}
			else
			{
				_messaging.CharacterNotValid(character);
			}

		}
	}
}
