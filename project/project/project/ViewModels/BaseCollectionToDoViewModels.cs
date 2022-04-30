using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace project.ViewModels
{
    /// <summary>
    /// Описывает коллекцию задач, связанную по критерию
    /// </summary>
    public abstract class BaseCollectionToDoViewModels
        : BaseViewModel
    {
        private Boolean isRefresh = false;

        public ICommand RefreshCommand { get; }

        protected BaseCollectionToDoViewModels()
        {
            InitializeCollectionViewModel();
            this.RefreshCommand = new Command((ob) => OnRefrash());
        }

        public virtual ObservableCollection<BaseViewModel> CollectionViewModels { get; } = new ObservableCollection<BaseViewModel>();
        public virtual Boolean IsRefresh
        {
            get => isRefresh;
            protected set
            {
                isRefresh = value;
                OnPropertyChanged(nameof(IsRefresh));
            }
        }

        public abstract String TitleCollection { get; }
        public abstract void InitializeCollectionViewModel();
        public abstract void OnRefrash();
    }
}