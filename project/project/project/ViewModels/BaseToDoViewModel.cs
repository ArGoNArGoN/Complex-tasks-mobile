using project.Models;
using project.Models.ToDo;

using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace project.ViewModels
{
	public abstract class BaseToDoViewModel
		: BaseViewModel
	{
		private Boolean isRefrash;
		private String stateMessage;
		protected BaseToDoModel model { get; private set; }

		public event Action Refrash;
		
		public BaseToDoViewModel(BaseToDoModel model)
		{
			this.model = model ?? throw new ArgumentNullException(nameof(model));

			CommitCommnd = new Command(() =>
			{
				OnCommit();

				IsRefrash = true;

				OnPropertyChanged(nameof(GetState));
				OnPropertyChanged(nameof(model.State.RollBackName));
				OnPropertyChanged(nameof(model.State.CommitName));

				IsRefrash = false;
			});
			RolbackCommnd = new Command(() =>
			{
				OnRolback();

				IsRefrash = true;

				OnPropertyChanged(nameof(GetState));
				OnPropertyChanged(nameof(model.State.RollBackName));
				OnPropertyChanged(nameof(model.State.CommitName));

				IsRefrash = false;
			});
		}

		public IStateToDo GetState { get => model.State; }

		public Int32 Identity { get => model.Identity; }
		public Int32 Count { get => model.Count; }
		public String Title { get => model.Title ?? ""; }
		public String Description { get => model.Description ?? ""; }
		public DateTime EndDate { get => model.EndDate; }
		public String Creator { get => model.Creator ?? ""; }
		public String Executor { get => model.Executor ?? ""; }
		public TimeSpan GetTimeSpan { get => model.EndDate - DateTime.Now; }

		public String CommitName { get => model.State.CommitName; }
		public String RollBackName { get => model.State.RollBackName; }
		public Boolean IsRefrash 
		{
			get => isRefrash; 
			set
			{
				if (isRefrash != value)
				{
					isRefrash = value;
					OnPropertyChanged(nameof(IsRefrash));
				}
			}
		}

		public virtual String StateMessage 
		{
			get => stateMessage;
			set 
			{
				stateMessage = value;
				OnPropertyChanged(nameof(StateMessage));
			}
		}

		protected abstract void OnCommit();
		protected abstract void OnRolback();

		public ICommand CommitCommnd { get; private set; }
		public ICommand RolbackCommnd { get; private set; }
		public virtual ICommand OnTapped
		{
			get => new Command(async (ob) =>
			{
				await Shell.Current.GoToAsync($"{nameof(Views.ListToDoView)}/{nameof(Views.ToDoView)}?Identity={((BaseToDoViewModel)ob).Identity}",
				true);
			});
		}

		protected void RefrashInvoke()
		{
			Refrash?.Invoke();
		}

		protected virtual Boolean IsCommit
			=> !String.IsNullOrEmpty(model.State.CommitName);
		protected virtual Boolean IsRolback
			=> !String.IsNullOrEmpty(model.State.RollBackName);

		public override string ToString()
		{
			return $"{model?.Identity.ToString() ?? "null"} | {model?.Title ?? "null"} | {model?.State?.Value ?? "null"}";
		}
	}
}
