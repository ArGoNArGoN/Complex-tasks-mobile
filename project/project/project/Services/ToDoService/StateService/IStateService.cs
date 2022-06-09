using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.ToDoService.StateService
{
    public interface IStateService<T>
    {
        IEnumerable<T> Get();
        T Get(int identity);
    }
}
