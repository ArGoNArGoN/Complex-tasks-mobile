namespace project.ViewModels
{
    /// <summary>
    /// Отвечает за отображение Активных и Ожиающих задач
    /// </summary>
    public class ToDoItmesViewModel
		: BaseViewModel
	{
		/// <summary>
		/// VM активных задач.
		/// Чтобы задать новый, продублируй и прокинь на View в BindingContext 
		/// </summary>
		public ActiveToDoListViewModel ActiveToDoListViewModel { get; }
		/// <summary>
		/// Инициализирует VM для работы с задачами
		/// </summary>
		public ToDoItmesViewModel()
		{
			ActiveToDoListViewModel = new ActiveToDoListViewModel();
		}
	}
}
