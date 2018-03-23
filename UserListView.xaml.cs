using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для UserListView.xaml
    /// </summary>
    public partial class UserListView : UserControl
    {
        public UserListView(Action<object, EventArgs> action)
        {
            InitializeComponent();
            DataContext = new UserListViewModel(UserDataGrid);
            AddUserButton.Click += action;
        }

        public void Remove(object o, EventArgs e)
        {
            Person person = (Person)UserDataGrid.SelectedItems[0];
            DBAdapter.Users.Remove(person);
        }

    }
}
