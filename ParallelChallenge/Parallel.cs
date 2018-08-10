using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

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
		public void ReturnWordParallelWithConcurrentQueue(string word)
		{
			var option = new ParallelOptions{MaxDegreeOfParallelism = 20 };
			ConcurrentQueue<string> wordSplited = new ConcurrentQueue<string>();
			word.Select(c => c.ToString()).ToList().ForEach(letter => wordSplited.Enqueue(letter));
			if (word.Length <= int.MaxValue)
			{
				Parallel.ForEach(wordSplited, character =>
				{
					string error = character;
					if (Words.TryGetValue(character.ToUpper(), out string value))
					{
						//Console.WriteLine(character + " as " + value);
						Thread.Sleep(25);
					}
					else
					{
						//Console.WriteLine(@"{0} is not a valid character", error.ToString());
					}

				});
			}
			else
			{
				Console.WriteLine("The Word must have less than 20 characters");
			}
			
		}
		public void ReturnWordParallelWithList(string word)
		{
			var option = new ParallelOptions { MaxDegreeOfParallelism = 20 };
			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			if (word.Length <= int.MaxValue)
			{
				Parallel.ForEach(wordSplited, character =>
				{
					string error = character;
					if (Words.TryGetValue(character.ToUpper(), out string value))
					{
						//Console.WriteLine(character + " as " + value);
						Thread.Sleep(25);
					}
					else
					{
						//Console.WriteLine(@"{0} is not a valid character", error.ToString());
					}

				});
			}
			else
			{
				Console.WriteLine("The Word must have less than 20 characters");
			}

		}
		public void ReturnWord(string word)
		{

			List<string> wordSplited = new List<string>(word.Select(c => c.ToString()).ToList());
			if (word.Length <= int.MaxValue)
			{
				foreach (var character in wordSplited)
				{
					string error = character;
					if (Words.TryGetValue(character.ToUpper(), out string value))
					{
						//Console.WriteLine(character + " as " + value);
						Thread.Sleep(25);
					}
					else
					{
						//Console.WriteLine(@"{0} is not a valid character", error.ToString());
					}
				}		
			}
			else
			{
				Console.WriteLine("The Word must have less than 20 characters");
			}

		}
	}
}
