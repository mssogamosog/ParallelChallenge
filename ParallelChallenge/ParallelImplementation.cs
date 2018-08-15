using System.Collections.Generic;

namespace ParallelChallenge
{
	public abstract class ParallelImplementation : IParallelImplementation
	{
		public IMessaging _messaging;

		public IGetValue _getValue;

		protected ParallelImplementation(IMessaging messaging, IGetValue getValue)
		{
			_messaging = messaging;
			_getValue = getValue;
		}

		public abstract void ReturnWord(string word);		
	}
}
