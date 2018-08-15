using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	public static class Constants
	{
		public static readonly ReadOnlyDictionary<string, string> Words =
			new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
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
			});
	}
}
