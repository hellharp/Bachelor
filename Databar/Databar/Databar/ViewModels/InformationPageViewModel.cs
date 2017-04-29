using Databar.Models;
using Databar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Databar.ViewModels
{
    public class InformationPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HelpItem> _helpList;
        private string location;

        public InformationPageViewModel(string page)
        {
            location = page;

            var helpService = new HelpServices();

            HelpList = helpService.getHelpList(location);
        }

        public ObservableCollection<HelpItem> HelpList
        {
            get { return _helpList; }
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
