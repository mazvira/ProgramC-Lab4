using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для FillOutForm.xaml
    /// </summary>
    public partial class FillOutForm : UserControl
    {
        private ImageAwesome _loader;

        public FillOutForm()
        {
            InitializeComponent();
            DataContext = new FillOutViewModel(ShowLoader);
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(FillGrid, ref _loader, isShow);
        }
    }
}
