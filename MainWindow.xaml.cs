using FontAwesome.WPF;
using System;
using System.ComponentModel;
using System.Windows;

namespace Lab4
{

    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;
        private UserListView _userListView;
        private FillOutForm _fillOutForm;

        public MainWindow()
        {
            InitializeComponent();
            ShowUsersListView();
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }

        private void ShowUsersListView()
        {
            if (_userListView == null)
            {
                _userListView = new UserListView(ShowFillOutForm);
            }
            else
                _userListView.Update();

            ShowView(_userListView);
        }

        private void ShowFillOutForm(object o, EventArgs e)
        {
            if (_fillOutForm == null)
            {
                _fillOutForm = new FillOutForm(ShowUsersListView);
            }
            ShowView(_fillOutForm);
        }

        private void ShowView(UIElement element)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(element);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DBAdapter.SaveData();
            base.OnClosing(e);
        }
    }
}
