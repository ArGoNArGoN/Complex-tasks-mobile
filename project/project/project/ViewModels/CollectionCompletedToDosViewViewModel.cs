using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace project.ViewModels
{
    [QueryProperty(nameof(ParameterIsRefresh), nameof(ParameterIsRefresh))]
    public class CollectionCompletedToDosViewViewModel
        : BaseViewModel
    {
        public BaseCollectionToDoViewModels CompletedToDosViewModel { get; }

        private Boolean isRefresh;
        private string parameterIsRefresh;

        public CollectionCompletedToDosViewViewModel()
        {
            CompletedToDosViewModel = new CompletedToDoCollectionViewModel();
        }
        public Boolean IsRefreshing
        {
            get { return isRefresh; }
            set
            {
                isRefresh = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public virtual String ParameterIsRefresh
        {
            get => parameterIsRefresh;
            set
            {
                parameterIsRefresh = value;
                if (Boolean.TryParse(value, out var result))
                    IsRefreshing = result;
            }
        }

        public ICommand RefreshButtonCommand => new Command(() => IsRefreshing = true);
        public ICommand RefreshCommand => new Command(() =>
        {
            CompletedToDosViewModel.RefreshCommand.Execute(this);

            IsRefreshing = false;
        });
    }
}
