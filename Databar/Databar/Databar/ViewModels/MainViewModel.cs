using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Databar.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        ICommand tapCommand;

        public MainViewModel()
        {
            tapCommand = new Command (OnTapped);
        }

        /// <summary>
        /// Expose the TapCommand via a property so tat Xaml can bind to it
        /// </summary>
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        /// <summary>
        /// Called whenever TapCommand is executed
        /// </summary>
        /// <param name="s"></param>
        void OnTapped(object s)
        {
            Debug.WriteLine("parameter: " + s);
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
