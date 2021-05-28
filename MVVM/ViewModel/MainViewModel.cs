using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfCommands.Base;
using WpfCommands.MVVM.Model;

namespace WpfCommands.MVVM.ViewModel
{
    public class MainViewModel : BindingBase
    {
        private SaveModel _savemodel;

        public SaveModel SaveModel
        {
            get =>_savemodel;
            set => SetPropertyValueToField(ref _savemodel, value);
        }

        private ViewModelBase _viewModelBase;

        public ViewModelBase  ViewModelBase
        {
            get => _viewModelBase;
            set => SetPropertyValueToField(ref _viewModelBase, value);
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetPropertyValueToField(ref _title, value);
            }
        }

        private Brush _appbackground;
        public Brush AppBackground
        {
            get
            {
                return _appbackground;
            }
            set
            {
                SetPropertyValueToField(ref _appbackground, value);
            }
        }

        private Brush _buttonBackground;
        public Brush ButtonBackground
        {
            get
            {
                return _buttonBackground;
            }
            set
            {
                SetPropertyValueToField(ref _buttonBackground, value);
            }
        }

        private Brush _titleForeground;

        public Brush TitleForeground
        {
            get { return _titleForeground; }

            set
            {
                SetPropertyValueToField(ref _titleForeground, value);
            }
        }

        public MainViewModel()
        {
            _title = "VTE App ";

            var color_title_background = (Color)ColorConverter.ConvertFromString("#00aba9");

            AppBackground = new SolidColorBrush(color_title_background);

            //var color_button_background = (Color)ColorConverter.ConvertFromString("#6cd100");
            //var Buttoncolor = new SolidColorBrush(color_button_background);

            //ButtonBackground = Buttoncolor;

            //TitleForeground = new SolidColorBrush(Colors.White);

            ViewModelBase = new ViewModelBase();

        }
    }
}
