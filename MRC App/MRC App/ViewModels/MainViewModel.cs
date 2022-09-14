using MRC_App.Services;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MRC_App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            _secureStorage = DependencyService.Get<ISecureStorageProvider>().SecureStorage;
            SetCommand = new Command(ExecuteSetCommand);
            GetCommand = new Command(ExecuteGetCommand);
            HasCommand = new Command(ExecuteHasCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand);
        }

        private string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (_key != value)
                {
                    _key = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _setVal;
        public string SetVal
        {
            get
            {
                return _setVal;
            }
            set
            {
                if (_setVal != value)
                {
                    _setVal = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _getVal;
        public string GetVal
        {
            get
            {
                return _getVal;
            }
            private set
            {
                if (_getVal != value)
                {
                    _getVal = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _hasVal;
        public string HasVal
        {
            get
            {
                return _hasVal;
            }
            private set
            {
                if (_hasVal != value)
                {
                    _hasVal = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _errMessage;
        public string ErrMessage
        {
            get
            {
                return _errMessage;
            }
            private set
            {
                if (_errMessage != value)
                {
                    _errMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GetCommand
        {
            get;
            private set;
        }

        public ICommand SetCommand
        {
            get;
            private set;
        }

        public ICommand HasCommand
        {
            get;
            private set;
        }

        public ICommand DeleteCommand
        {
            get;
            private set;
        }

        private void ExecuteSetCommand(object sender)
        {
            ErrMessage = string.Empty;
            try
            {
                _secureStorage.SetValue(Key, SetVal);
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }

        private void ExecuteGetCommand(object sender)
        {
            ErrMessage = string.Empty;
            try
            {
                GetVal = _secureStorage.GetValue(Key);
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }

        private void ExecuteHasCommand(object sender)
        {
            ErrMessage = string.Empty;
            try
            {
                HasVal = _secureStorage.HasKey(Key) ? "Y" : "N";
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }

        private void ExecuteDeleteCommand(object sender)
        {
            ErrMessage = string.Empty;
            try
            {
                bool success = _secureStorage.DeleteKey(Key);
                ErrMessage = success.ToString();
                if (success)
                {
                    GetVal = string.Empty;
                    HasVal = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrMessage = ex.Message;
            }
        }

        private readonly ISecureStorage _secureStorage;
    }
}
