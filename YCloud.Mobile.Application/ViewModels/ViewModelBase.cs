using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using YCloud.Mobile.Application.Interfaces;

namespace YCloud.Mobile.Application.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private object _navigationParameters;

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetNavigationParameters(object parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            if (_navigationParameters != null)
                throw new InvalidOperationException("Navigation parameters already set");

            _navigationParameters = parameters;
        }

        protected T GetNavigationParameters<T>() where T : class
        {
            if (_navigationParameters == null)
                return null;

            if (!(_navigationParameters is T))
                throw new InvalidCastException("Invalid cast to expected type");

            return (T)_navigationParameters;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
