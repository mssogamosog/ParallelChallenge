using System.Collections.Generic;

namespace ParallelChallenge
{
	public abstract class ParallelImplementation
	{
		private Dictionary<string, string> Words =
			new Dictionary<string, string>
			{
			{ "A", "Anime" },
			{ "B", "Bosnia" },
			{ "C", "Canvas" },
			{ "D", "Dormer" },
			{ "E", "Extreme" },
			{ "F", "Feature" },
			{ "G", "Gross" },
			{ "H", "Hypothetical" },
			{ "I", "Isle" },
			{ "J", "Junior" },
			{ "K", "Key" },
			{ "L", "Lazy" },
			{ "M", "Moriarty" },
			{ "N", "Nurse" },
			{ "O", "Osaka" },
			{ "P", "Python" },
			{ "Q", "Query" },
			{ "R", "Rose" },
			{ "S", "Sand" },
			{ "T", "Thursday" },
			{ "U", "Uniform" },
			{ "V", "Value" },
			{ "W", "West" },
			{ "X", "Xylophone" },
			{ "Y", "Yuri" },
			{ "Z", "Zyra" }
			};

		protected void GetValue(string character)
		{
			if (Words.TryGetValue(character.ToUpper(), out string value))
			{
				//Console.WriteLine(character + " as " + value);
				//Thread.Sleep(1);
			}
			else
			{
				//Console.WriteLine(@"{0} is not a valid character", character);
			}
			
		}
		public abstract void ReturnWord(string word);		
	}
}
