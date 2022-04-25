using System;

namespace project.Models.ToDo.ToDoState
{
    /// <summary>
    /// Описывает состояние выполненной задачи
    /// </summary>
    public class CompletedToDoSubsState
        : BaseCompletedToDoState, IStateToDo
    {
        public String CommitName => "";
        public String RollBackName => "Отменить";
        public String Value => "Завершенная";

        public String Commit(Object obj, Action<IStateToDo> setState)
        {
            return "Задача уже выполнена!";
        }

        /// <summary>
        /// Ожидающая задача <- Активная задача.
        /// </summary>
        /// <param name="obj">Подзадача</param>
        /// <param name="setState">Операция с присвоением состояния</param>
        public String RollBack(Object obj, Action<IStateToDo> setState)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            else if (setState is null)
                throw new ArgumentNullException(nameof(setState));

            else if (!(obj is BaseToDoModel))
                throw new InvalidCastException(nameof(obj));

            /* прописать логику */

            setState.Invoke(new ActiveToDoSubsState());

            return "Задача стала активной";
        }
    }
}