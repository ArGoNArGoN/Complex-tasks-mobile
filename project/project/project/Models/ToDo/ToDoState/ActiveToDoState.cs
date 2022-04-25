using System;

namespace project.Models.ToDo.ToDoState
{
    public class ActiveToDoState
        : BaseActiveToDoState, IStateToDo
    {
        public String CommitName => "Завершить";
        public String RollBackName => "Отменить";
        public String Value => "Активная";

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

            setState.Invoke(new CompletedToDoState());

            return "Задача выполнена";
        }

        /// <summary>
        /// Ожидающая задача <- Активная задача.
        /// </summary>
        /// <param name="obj">Задача</param>
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

            setState.Invoke(new PendingToDoState());

            return "Задача стала ожидающей";
        }
    }
}
