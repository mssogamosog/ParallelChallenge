﻿using System.Collections.Generic;

namespace ParallelChallenge
{
	public abstract class ParallelImplementation : IParallelImplementation
	{
		public IMessaging _messaging;

		public ParallelImplementation(IMessaging messaging)
		{
			_messaging = messaging;
		}

		

		public void GetValue(string character)
		{
			if (Constants.Words.TryGetValue(character.ToUpper(), out string value))
			{
				_messaging.ShowResult(character,value);
				//Thread.Sleep(1);
			}
			else
			{
				_messaging.CharacterNotValid(character);
			}
			
		}
		public abstract void ReturnWord(string word);		
	}
}
