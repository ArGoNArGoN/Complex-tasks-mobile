using project.Models;
using project.Services.Entitys;
using System;

namespace project.Services
{
    public abstract class BaseToDoRepository
    {
        internal readonly ToDoDataBaseContext ToDoContext;
        internal readonly SubToDoDataBaseContext SubToDoContext;

        public BaseToDoRepository()
        {
            ToDoContext = new ToDoDataBaseContext(App.connection);
            SubToDoContext = new SubToDoDataBaseContext(App.connection);
        }

        public void UpdateSubToDo(SubToDoModel model, Int32 id)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var entity = new SubToDoEntity()
            {
                Identity = model.Identity,
                Status = model.Status ? 1 : 0,
                Title = model.Title,
                ToDoIdentity = id
            };

            SubToDoContext.Update(entity);
        }
    }
}