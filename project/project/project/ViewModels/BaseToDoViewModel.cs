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
		private Boolean isRefresh;
		private String stateMessage;

		protected BaseToDoModel model { get; private set; }

		public event Action Refrash;

		public BaseToDoViewModel(BaseToDoModel model)
		{
			this.model = model ?? throw new ArgumentNullException(nameof(model));

			CommitCommnd = new Command(() =>
			{
				OnCommit();

				IsRefresh = true;

				OnPropertyChanged(nameof(GetState));
				OnPropertyChanged(nameof(model.State.RollBackName));
				OnPropertyChanged(nameof(model.State.CommitName));

				IsRefresh = false;
			});
			RolbackCommnd = new Command(() =>
			{
				OnRolback();

				IsRefresh = true;

				OnPropertyChanged(nameof(GetState));
				OnPropertyChanged(nameof(model.State.RollBackName));
				OnPropertyChanged(nameof(model.State.CommitName));

				IsRefresh = false;
			});
		}

		public IStateToDo GetState { get => model.State; }

		public Int32 Identity { get => model.Identity; }
		public Int32 Count { get => model.Count; }
		public String Title { get => model.Title ?? ""; }
		public String Description { get => model.Description ?? ""; }
		public DateTime EndDate { get => model.EndDate; }
		public string Creator { get => model.Creator ?? ""; }
		public String Executor { get => model.Executor ?? ""; }
		public TimeSpan GetTimeSpan { get => model.EndDate - DateTime.Now; }

		public String CommitName { get => model.State.CommitName; }
		public String RollBackName { get => model.State.RollBackName; }
		public Boolean IsRefresh
		{
			get => isRefresh;
			set
			{
				if (isRefresh != value)
				{
					isRefresh = value;
					OnPropertyChanged(nameof(IsRefresh));
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
