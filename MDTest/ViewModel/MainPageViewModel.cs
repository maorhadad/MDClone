using MDTest.Model;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MDTest.ViewModel
{
    public class MainPageViewModel: INotifyPropertyChanged
    {

        public ICommand AddEmailCommand { get; set; }
        public ICommand AddDataTableCommand { get; set; }

        public MainPageViewModel()
        {
            Tabs = new ObservableCollection<TabViewModel>();
            AddEmailCommand = new DelegateCommand(AddEmailPage);
            AddDataTableCommand = new DelegateCommand(AddDataTable);
        }

        public ObservableCollection<TabViewModel> Tabs
        {
            get;
            set;
        }

        public TabModel SelectedTab
        {
            get;
            set;
        }

        private void AddEmailPage()
        {
            Tabs.Add(new EmailViewModel(new EmailModel($@"Email:{Tabs.Count + 1}"))); ;
            OnPropertyChanged("Tabs");
        }
        private void AddDataTable()
        {
            Tabs.Add(new DataTableViewModel( new DataTableModel($@"Data Table:{Tabs.Count + 1}")));
            OnPropertyChanged("Tabs");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
