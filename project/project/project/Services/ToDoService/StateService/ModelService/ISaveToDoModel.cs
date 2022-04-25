namespace project.Services.ToDoService.StateService.ModelService
{
	public interface ISaveToDoModel<T>
	{
		void Save(T model);
	}
}
