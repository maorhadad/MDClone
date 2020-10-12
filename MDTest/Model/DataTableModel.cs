using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTest.Model
{
    public class DataTableModel : TabModel
    {
        public string DataTableName;
        public ObservableCollection<Person> persons;
        public DataTableModel(string tabName) : base(tabName)
        {
            DataTableName = $@"Name: {tabName}";
           
        }

        internal void OnNewFileLoaded(string json)
        {
            persons = JsonConvert.DeserializeObject<ObservableCollection<Person>>(json);
        }
    }
}
