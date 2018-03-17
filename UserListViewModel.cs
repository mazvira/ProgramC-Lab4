using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        }

        public void Remove(object o, EventArgs e)
        {
            Person person = (Person)_dataGrid.SelectedItems[0];
            DBAdapter.Users.Remove(person);

        }

        public void Add(object o, EventArgs e)
        {
           
        }

        public void Edit(object o, EventArgs e)
        {
            _dataGrid.CellEditEnding = 
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
