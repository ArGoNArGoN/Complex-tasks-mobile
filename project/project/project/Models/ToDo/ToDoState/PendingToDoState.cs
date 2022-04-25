using System;

namespace project.Models.ToDo.ToDoState
{
    /// <summary>
    /// Описывает состояние ожидающей подзадачи
    /// </summary>
    public class PendingToDoState
        : BasePendingToDoState, IStateToDo
    {
        public String RollBackName => ""; 
        public String CommitName => "Перейти к выполнению";
        public String Value => "Ожидающая";

        /// <summary>
        /// Ожидающая задача -> Активная задача.
        /// </summary>
        /// <param name="obj">Задача</param>
        /// <param name="setState">Операция с присвоением состояния</param>
        public String Commit(Object obj, Action<IStateToDo> setState)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            
            else if (setState is null)
                throw new ArgumentNullException(nameof(setState));

            else if (!(obj is BaseToDoModel))
                throw new InvalidCastException(nameof(obj));

            /* прописать логику */

            setState.Invoke(new ActiveToDoState());
            return "Задача стала активной";
        }
        public String RollBack(Object obj, Action<IStateToDo> setState)
        {
            return "Задача уже является ожидающей!";
        }
    }
}
