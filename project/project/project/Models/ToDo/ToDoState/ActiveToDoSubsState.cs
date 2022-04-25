using System;
using System.Linq;

namespace project.Models.ToDo.ToDoState
{
	/// <summary>
	/// Описывает состояние активной задачи.
	/// </summary>
    public class ActiveToDoSubsState
		: BaseActiveToDoState, IStateToDo
	{
		public String CommitName => "Завершить";
		public String RollBackName => "Отменить выполнение";

        public String Value => "Активная";

        /// <summary>
        /// Ожидающая задача -> Активная задача.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="setState"></param>
        public String Commit(Object obj, Action<IStateToDo> setState)
		{
			if (obj is null || setState is null)
				throw new ArgumentNullException();

			else if (setState is null)
				throw new ArgumentNullException(nameof(setState));

			var model = obj as ToDoSubsModel;

			if (model is null)
				throw new InvalidCastException(nameof(obj));

			else if (!model.SubToDos.Any(x => x.State is BaseCompletedSubToDoState))
				return "Не все подзадачи выполнены!";

			setState.Invoke(new CompletedToDoSubsState());

			return "Задача выполнена";
		}
		/// <summary>
		/// Завершенная задача -> Активная задача.
		/// </summary>
		/// <param name="obj">Задача</param>
		/// <param name="setState">Операция с присвоением состояния</param>
		public String RollBack(Object obj, Action<IStateToDo> setState)
		{
			if (obj is null || setState is null)
				throw new ArgumentNullException();

			else if (setState is null)
				throw new ArgumentNullException(nameof(setState));

			else if (!(obj is BaseToDoModel))
				throw new InvalidCastException(nameof(obj));

			setState.Invoke(new PendingToDoSubsState());

			return "Задача стала ожидающей";
		}
	}
}
