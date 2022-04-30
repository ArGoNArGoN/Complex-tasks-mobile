using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.ToDoService.StateService.ModelService
{
    public interface ISaveSubToDoModel<T>
    {
        void Save(T model);
    }
}
