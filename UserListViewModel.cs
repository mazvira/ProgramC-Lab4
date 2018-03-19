using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            _dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _dataRow = e.Row.Item as DataRowView;
            string text = ((TextBox)e.EditingElement).Text;
            string column =  e.Column.Header.ToString();
            switch (column)
            {
                case "First name":
                    break;
                case "Last name":
                    break;
                case "E-mail":
                    if(IsValidEmail(_email) == false)
                        e.Cancel = true;
                    break;
                case "Date of birth":
                    break;
                case "Age":
                   if( Age > 135 || Age <0)
                    break;
                case "IsAdult":
                    break;
                case "SunSign":
                    break;
                case "ChineseSign":
                    break;
                case "IsBirthday":
                    break;
            }
                      
        }

        public void Remove(object o, EventArgs e)
        {
            Person person = (Person)_dataGrid.SelectedItems[0];
            DBAdapter.Users.Remove(person);
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
