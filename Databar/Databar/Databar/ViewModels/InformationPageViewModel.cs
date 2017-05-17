using Databar.Models;
using Databar.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Databar.ViewModels
{
    /// <summary>
    /// The ViewModel for InformationPage
    /// </summary>
    public class InformationPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HelpItem> _helpList;

        /// <summary>
        /// Constructor for InformatoinPageViewModel
        /// </summary>
        /// <param name="location">The view that calls the function</param>
        public InformationPageViewModel(string location)
        {
            HelpServices helpService = new HelpServices();

            HelpList = helpService.getHelpList(location);
        }

        public ObservableCollection<HelpItem> HelpList
        {
			get {
				return _helpList;
			}
            set
            {
                _helpList = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
