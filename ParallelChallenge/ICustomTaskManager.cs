using System.Collections.Concurrent;

namespace ParallelChallenge
{
	public interface ICustomTaskManager
	{
		void RunTask(string word, ConcurrentQueue<string> wordSplited);
	}
}