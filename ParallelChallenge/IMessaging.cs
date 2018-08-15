using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	public interface IMessaging
	{
		void InvalidWord();
		void Exception(Exception ex);
		void CharacterNotValid(string character);
		void ShowResult(string character, string value);
	}
}
