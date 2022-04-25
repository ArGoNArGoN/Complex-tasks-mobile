using System;

namespace project.Models.ToDo.ToDoState
{
    /// <summary>
    /// Описывает состояние выполненной подзадачи.
    /// </summary>
    public class CompletedSubState
        : BaseCompletedToDoState, IState<SubModel>
    {
        public string Value => "CompletedState";

        [Obsolete("Выдаст ошибку")]
        public void Commit(SubModel obj, Action<IState<SubModel>> setState)
        {
            throw new InvalidOperationException("Нельзя подняться выше");
        }
        
        /// <summary>
        /// Ожидающая подзадача <- Активная подзадача.
        /// </summary>
        /// <param name="obj">Подзадача</param>
        /// <param name="setState">Операция с присвоением состояния</param>
        public void RollBack(SubModel obj, Action<IState<SubModel>> setState)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            else if (setState is null)
                throw new ArgumentNullException(nameof(setState));

            /* прописать логику */

            setState.Invoke(new PendingSubState());
        }
    }
}
