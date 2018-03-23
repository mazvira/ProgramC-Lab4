using FontAwesome.WPF;
using System.Windows.Controls;

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
            DataContext = new FillOutFormViewModel(ShowLoader);
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(FillGrid, ref _loader, isShow);
        }
    }
}
