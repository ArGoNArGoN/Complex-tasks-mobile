using project.Models.ToDo;
using project.Models.ToDo.ToDoState;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace project.ViewModels
{
    public sealed class ToDoSubsViewModel
		: BaseToDoViewModel
	{
		private ToDoSubsModel _model;
		private ObservableCollection<BaseSubToDoViewModel> CollectionSubToDos { get; }

		public ToDoSubsViewModel(ToDoSubsModel model)
			: base(model) 
		{
			CollectionSubToDos = new ObservableCollection<BaseSubToDoViewModel>(model.SubToDos.Select(x => new SubToDoViewModel(x)));
			CollectionSubToDosViewModel = new SubToDosCollectionViewModel(CollectionSubToDos);
			this._model = model;
		}

		public SubToDosCollectionViewModel CollectionSubToDosViewModel { get; }

		public Int32 CountSubs { get => _model.SubToDos.Count(); }
		public Int32 CompletedSubs { get => _model.SubToDos.Where(x => x.State is BaseCompletedSubToDoState).Count(); }

		protected override void OnCommit()
		{
			StateMessage = model.Commit();
		}
		protected override void OnRolback()
		{
			StateMessage = model.RollBack();
		}
	}
}
