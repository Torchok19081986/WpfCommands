using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfCommands.MVVM.ViewModel
{

    /* 
     * 
     * I will use the MVVM-Toolkit because it is very stable and does the needed implementation for us. 
     * 
     */
    public class TimsViewModel : ObservableValidator
    {
        public TimsViewModel()
        {
            GreetMeCommand = new RelayCommand<string>((name) => GreetMe(name), (name) => !string.IsNullOrEmpty(name));

            // We want to validate after creation already
            ValidateAllProperties();
        }

        private string _Name;
        [Required]
        [RegularExpression(@"(.*[A-Za-z]){3}")]
        public string Name
        {
            get { return _Name; }
            set 
            {
                if (SetProperty(ref _Name, value, true))
                {
                    // Let's update the command if we changed the name
                    GreetMeCommand.NotifyCanExecuteChanged();
                }
            }
        }

        private int _Age = -1;
        [Range (0,125)]
        public int Age
        {
            get { return _Age; }
            set { SetProperty(ref _Age, value, true); }
        }


        public RelayCommand<string> GreetMeCommand { get; }

        private void GreetMe(string name)
        {
            MessageBox.Show($"Hi \"{name}\", you are only {Age} years old?");
        }

    }
}
