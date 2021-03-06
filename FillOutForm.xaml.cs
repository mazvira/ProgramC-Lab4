﻿using FontAwesome.WPF;
using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для FillOutForm.xaml
    /// </summary>
    public partial class FillOutForm : UserControl
    {
        private ImageAwesome _loader;

        public FillOutForm(Action action)
        {
            InitializeComponent();
            DataContext = new FillOutFormViewModel(ShowLoader, action);

        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(FillGrid, ref _loader, isShow);
        }
    }
}
