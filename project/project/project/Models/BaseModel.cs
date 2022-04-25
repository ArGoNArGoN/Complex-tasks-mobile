using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace project.Models
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public abstract class BaseModel
        : INotifyPropertyChanged
    {
        public BaseModel()
        {
        }

        /// <summary>
        /// событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

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
