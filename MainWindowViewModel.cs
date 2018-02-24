using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        private string _age;
        private string _westHoroscope;
        private string _chineseHoroscope;
        private string _name;
        private string _lastName;
        private string _email;
        private bool _canExecute;
        private RelayCommand _countAge;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;

        public MainWindowViewModel(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
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
            set { _dateOfBirth = value; OnPropertyChanged(); }

        }
        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public RelayCommand CountAge
        {
            get
            {
                return _countAge ?? (_countAge = new RelayCommand(CountAgeImpl));
            }
        }
        public string WestHoroscope
        {
            get { return _westHoroscope; }
            set { _westHoroscope = value; OnPropertyChanged(); }
        }

        public string ChineseHoroscope
        {
            get { return _chineseHoroscope; }
            set { _chineseHoroscope = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private async void CountAgeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentPerson = PersonAdapter.CreatePerson(_name, _lastName, _email,_dateOfBirth);
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentPerson == null)
                MessageBox.Show($"Date of birth {_dateOfBirth} is  invalid.");

            else
            {
                if (_dateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("Happy Birthday");
                Name = StationManager.CurrentPerson.Name;
                LastName = StationManager.CurrentPerson.LastName;
                Email = StationManager.CurrentPerson.Email;
                Age = $"{StationManager.CurrentPerson.Age}";
                WestHoroscope = StationManager.CurrentPerson.SunSign;
                ChineseHoroscope = StationManager.CurrentPerson.ChineseSign;

                _closeAction.Invoke();
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
