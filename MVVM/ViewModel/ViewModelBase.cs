using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCommands.Commands;
using WpfCommands.MVVM.Model;

namespace WpfCommands.MVVM.ViewModel
{
    public class ViewModelBase
    {
        private ICommand _clickCommand;

        private ICommand _clickCommand2;

        private ICommand _saveCommand;

        private ICommand _testCommand;

        public ICommand ClickCommand => _clickCommand ??= new RelayCommand(param => MyActionButton1(param), param => CanExecute);

        public ICommand ClickCommand2 => _clickCommand2 ??= new RelayCommand(param => MyActionButton2(param), param => CanExecute);

        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(param => OnSaveExecute(param), param => CanSaveExecute);

        public ICommand TestCommand => _testCommand ??= new RelayCommand<string>((myString) => DoSomeStuff(myString), (myString) => CanDoSomeStuff(myString));

        public static bool CanDoSomeStuff(object parameter)
        {
            //  return !string.IsNullOrEmpty(parameter.ToString());

            return true;
        }

        public static void DoSomeStuff(object parameter)
        {
            parameter = "Test";

            MessageBox.Show(parameter.ToString());

        }

        public void OnSaveExecute(object param)
        {
            if (param != null)
            {
                object[] values = (object[])param;
                if (values != null || values.Length > 0)
                {
                    SaveModel saveModel = new();
                    saveModel.Name = (string)values[0];
                    saveModel.Vorname = (string)values[1];
                    saveModel.Age = int.TryParse((string)values[2], out int age) ? age : 0;
                    saveModel.Country = (string)values[3];
                    MessageBoxResult messageBoxResult = MessageBox.Show("Save Command Invoke und speichern von " + saveModel.Name + " " + saveModel.Vorname + " and " + saveModel.Age + " in Country " + saveModel.Country + " was initialized.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void OnTestExecute(object param)
        {
            if (param != null)
            {
                MessageBox.Show("Test Command Invoke und was initialized.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void MyActionButton2(object param)
        {
            param = "Warning Message";
            MessageBox.Show("MyAction2 was invoked. " + param, "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public bool CanExecute
        {
            get { return true; }
        }

        public bool CanSaveExecute
        {
            get { return true; }
        }
        public bool CanTestExecute
        {
            get { return true; }
        }

        public void MyActionButton1(object param)
        {
            param = "Test 2";
            MessageBox.Show("MyAction was invoked. " + param, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
    public class RelayCommand<T> : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canexecute)
        {
            _execute = execute;
            _canExecute = canexecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
