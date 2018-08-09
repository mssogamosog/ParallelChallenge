using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			ParallelImplementation p = new ParallelImplementation();
			Console.WriteLine("Write Word to be procesed");
			string word = Console.ReadLine();
			p.ReturnWord(word);
		}
	}
}
