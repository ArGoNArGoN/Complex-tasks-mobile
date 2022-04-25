using System;

namespace project.Models.ToDo.ToDoState
{
    /// <summary>
    /// Описывает состояние ожидающей подзадачи.
    /// </summary>
    public class PendingSubState 
        : BasePendingSubToDoState, IState<SubModel>
    {
        /// <summary>
        /// Ожидающая подзадача -> Активная подзадача.
        /// </summary>
        /// <param name="obj">Подзадача</param>
        /// <param name="setState">Операция с присвоением состояния</param>
        public void Commit(SubModel obj, Action<IState<SubModel>> setState)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            else if (setState is null)
                throw new ArgumentNullException(nameof(setState));

            /* прописать логику */

            setState.Invoke(new CompletedSubState());
        }

        [Obsolete("Выдаст ошибку")]
        public void RollBack(SubModel obj, Action<IState<SubModel>> setState)
        {
            throw new InvalidOperationException("Нельзя опуститься ниже");
        }

        public String Value { get; } = "PendingState";
    }
}