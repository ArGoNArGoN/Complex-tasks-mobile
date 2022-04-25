using System;

namespace project.Models
{
    public interface IStateToDo
	{
		String RollBackName { get; }
		String CommitName { get; }

		String Commit(Object obj, Action<IStateToDo> setState);
		String RollBack(Object obj, Action<IStateToDo> setState);

		String Value { get; }
	}
}
