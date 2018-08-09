using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ParallelChallenge
{
	public class ParallelImplementation
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
		public void ReturnWord(string word)
		{
			var option = new ParallelOptions{MaxDegreeOfParallelism = 20 };
			ConcurrentQueue<string> wordSplited = new ConcurrentQueue<string>();
			word.Select(c => c.ToString()).ToList().ForEach(letter => wordSplited.Enqueue(letter));
			if (word.Length <= 20)
			{
				Parallel.ForEach(wordSplited, character =>
				{
					string value;
					if (Words.TryGetValue(character.ToUpper(), out value))
					{
						Console.WriteLine(character + " as " + value);
					}
					else
					{
						Console.WriteLine(@"{0} is not a valid character", character);
					}
					
				});
			}
			else
			{
				Console.WriteLine("The Word must have less than 20 characters");
			}
			
		}
	}
}
