﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4
{
    class FillOutFormViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth = DateTime.Today;
        private string _age;
        private string _name;
        private string _lastName;
        private string _email;
        private bool _canExecute;
        private RelayCommand _countAge;
        private Action _closingAction;
        private readonly Action<bool> _showLoaderAction;


        public FillOutFormViewModel(Action<bool> showLoader, Action action)
        {
            _showLoaderAction = showLoader;
            _closingAction = action;
            CanExecute = true;
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set { _canExecute = value; OnPropertyChanged(); }

        }

        public DateTime Date
        {
            get { return _dateOfBirth; }
            private set { _dateOfBirth = value; OnPropertyChanged(); }
        }

        public string Age
        {
            get { return String.IsNullOrWhiteSpace(_age) ? "" : $"You are {_age} years of old"; }
            private set { _age = value; OnPropertyChanged(); }
        }

        public RelayCommand CountAge
        {
            get
            {
                return _countAge ?? (_countAge = new RelayCommand(CountAgeImpl, o => !String.IsNullOrWhiteSpace(_name) && _dateOfBirth != DateTime.MinValue &&
                            !String.IsNullOrWhiteSpace(_lastName) && !String.IsNullOrWhiteSpace(_email)));
            }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; OnPropertyChanged(); }
        }

        public string NameForResult
        {
            get { return String.IsNullOrWhiteSpace(_name) ? "" : $"Your name is {_name}"; }
        }

        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; OnPropertyChanged(); }
        }

        public string LastNameForResult
        {
            get { return String.IsNullOrWhiteSpace(_lastName) ? "" : $"Your surname is {_lastName}"; }
        }

        public string Email
        {
            get { return _email; }
            private set { _email = value; OnPropertyChanged(); }
        }

        public string EmailForResult
        {
            get { return String.IsNullOrWhiteSpace(_email) ? "" : $"Your email is {_email}"; }
        }

        private async void CountAgeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentPerson = DBAdapter.CreatePerson(_name, _lastName, _email, _dateOfBirth);
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentPerson == null)
                MessageBox.Show($"Date of birth {_dateOfBirth} is  invalid.");

            else
            {
                if (_dateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("Happy Birthday");
                _closingAction.Invoke();
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
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
