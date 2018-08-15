using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	public class Messaging : IMessaging
	{
		public void InvalidWord()
		{
			Console.WriteLine("The Word must have less than 20 characters");
		}
		public void Exception(Exception ex)
		{
			Console.WriteLine("The exception is: " + ex.Message);
		}
		public void CharacterNotValid(string character)
		{
			Console.WriteLine(@"{0} is not a valid character", character);
		}
		public void ShowResult(string character,string value)
		{
			Console.WriteLine(character + " as " + value);
		}

	}
}
