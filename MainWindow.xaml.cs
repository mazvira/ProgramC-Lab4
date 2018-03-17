using FontAwesome.WPF;
using System;
using System.Windows;


namespace Lab4
{
 
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(ShowLoader);
            //DataContext = new UserListView;
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }

    }
}
