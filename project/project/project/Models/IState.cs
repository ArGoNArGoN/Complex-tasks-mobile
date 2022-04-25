using System;

namespace project.Models
{
	public interface IState<T>
	{
		void Commit(T obj, Action<IState<T>> setState);
		void RollBack(T obj, Action<IState<T>> setState);

		String Value { get; }
	}
}
