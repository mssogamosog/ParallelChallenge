using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ParallelChallenge
{
	public interface ICustomTaskManager
	{
		void RunTask( List<string> wordSplited);
	}
}