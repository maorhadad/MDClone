using MDTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MDTest.ViewModel
{
    public class TabViewModel : INotifyPropertyChanged
    {
        private TabModel TabModel;

        public TabViewModel(TabModel tabModel)
        {
            TabModel = tabModel;
        }

        public string TabName
        {
            get
            {
                return TabModel.name;
            }

            set
            {
                if (TabModel.name != value)
                {
                    TabModel.name = value;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
