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
        private Boolean isRefrash = false;

        public ICommand RefrashCommand { get; }

        protected BaseCollectionToDoViewModels()
        {
            InitializeCollectionViewModel();
            this.RefrashCommand = new Command((ob) => OnRefrash());
        }

        public virtual ObservableCollection<BaseViewModel> CollectionViewModels { get; } = new ObservableCollection<BaseViewModel>();
        public virtual Boolean IsRefrash
        {
            get => isRefrash;
            protected set
            {
                isRefrash = value;
                OnPropertyChanged(nameof(IsRefrash));
            }
        }

        public abstract String TitleCollection { get; }
        public abstract void InitializeCollectionViewModel();
        public abstract void OnRefrash();
    }
}