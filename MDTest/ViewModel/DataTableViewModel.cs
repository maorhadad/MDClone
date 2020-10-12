using MDTest.Model;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.IO;
using System;
using System.Windows.Forms;

namespace MDTest.ViewModel
{
    public class DataTableViewModel : TabViewModel
    {
        private DataTableModel DataTableModel;
        public ICommand LoadFileCommand { get; set; }

        public DataTableViewModel(DataTableModel DataTableModel) : base(DataTableModel)
        {
            this.DataTableModel = DataTableModel;
            LoadFileCommand = new DelegateCommand(LoadFile);
        }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return DataTableModel.persons;
            }
            set
            {
                if (DataTableModel.persons != value)
                {
                    DataTableModel.persons = value;
                }
            }
        }


        public string DataTableName
        {
            get
            {
                return DataTableModel.DataTableName;
            }

            set
            {
                if (DataTableModel.DataTableName != value)
                {
                    DataTableModel.DataTableName = value;
                }
            }
        }

        private void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTableModel.OnNewFileLoaded(File.ReadAllText(openFileDialog.FileName));
                }catch(Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error on parsing json file.", MessageBoxButtons.OK);
                }
                OnPropertyChanged("Persons");
            }
                
        }
    }
}
