using FontAwesome.WPF;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для FillOutForm.xaml
    /// </summary>
    public partial class FillOutForm : UserControl
    {
        private ImageAwesome _loader;

        public FillOutForm(Action<object, EventArgs> action)
        {
            InitializeComponent();
            DataContext = new FillOutFormViewModel(ShowLoader);
            SaveUserButton.Click += new RoutedEventHandler(action);
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(FillGrid, ref _loader, isShow);
        }
    }
}
