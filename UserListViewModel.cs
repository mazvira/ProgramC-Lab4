using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Lab4
{
    class UserListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _users;
        private DataGrid _dataGrid;
        private DataRowView _dataRow;

        public ObservableCollection<Person> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        internal UserListViewModel(DataGrid dataGrid)
        {
            _users = new ObservableCollection<Person> (DBAdapter.Users);
            _dataGrid = dataGrid;
            _dataGrid.CellEditEnding += DataGrid_CellEditEnding; //add event 

        }

        //eventHaNDLER
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _dataRow = e.Row.Item as DataRowView;
            string text = ((TextBox)e.EditingElement).Text;
            string column =  e.Column.Header.ToString();
            switch (column)
            {
              
                case "E-mail":
                    if(Person.IsValidEmail(text) == false)
                        e.Cancel = true;
                    break;
                case "Date of birth":

                    string[] date = text.Split('/');
                    if(Int32.Parse(date[0]) > 31 || Int32.Parse(date[0])<1|| Int32.Parse(date[1])>12 || Int32.Parse(date[1]) <1 || Int32.Parse(date[2])<1883|| Int32.Parse(date[2])>2018)
                        e.Cancel = true;
                    //create DateTime (parse to int date items)
                    string b = date[2].ToString();
                    DateTime dateNew = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[1]), Int32.Parse(date[0]));
                    try
                    {
                        Person.CountAge(dateNew);
                    }
                    catch(Exception exception)
                    {
                        e.Cancel = true;
                    }

                    break;
      
            }
                      
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
