using System;

namespace project.Models.ToDo.ToDoState
{
    /// <summary>
    /// Описывает состояние выполненной задачи.
    /// </summary>
    public class CompletedToDoState
        : BaseCompletedToDoState, IStateToDo
    {
        public String RollBackName => "Отменить";
        public String CommitName => "";

        public String Value => "Завершенная";

        [Obsolete("Выдаст ошибку")]
        public String Commit(Object obj, Action<IStateToDo> setState)
        {
            return "Задача уже выполнена!";
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

            /* прописать логику */

            setState.Invoke(new ActiveToDoState());

            return "Задача стала активной";
        }
    }
}
