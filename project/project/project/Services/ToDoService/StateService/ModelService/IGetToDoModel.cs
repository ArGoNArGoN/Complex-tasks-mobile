using System.Collections.Generic;

namespace project.Services.ToDoService.StateService.ModelService
{
    public interface IGetToDoModel<T>
    {
        IEnumerable<T> Get();
    }
}