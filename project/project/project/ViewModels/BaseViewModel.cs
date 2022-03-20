using System;
using System.ComponentModel;

namespace project.ViewModels
{
    /// <summary>
    /// Базовая сущность для ViewModel
    /// </summary>
    public class BaseViewModel
        : INotifyPropertyChanged
    {
        protected String titlePage;

        /// <summary>
        /// Название страницы
        /// </summary>
        public virtual String TitlePage
        {
            get { return titlePage; }
            protected set 
            {
                titlePage = value;
                OnPropertyChanged(nameof(TitlePage)); /// обновляет значение
            }
        }
        /// <summary>
        /// событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
        }

        /// <summary>
        /// Возникает при изменении свойства
        /// </summary>
        /// <param name="propertyName">Название свойства</param>
        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
