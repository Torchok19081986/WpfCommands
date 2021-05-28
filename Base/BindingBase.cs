using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfCommands.Base
{
    public class BindingBase : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Eine Reference zu private Feldname</typeparam>
        /// <param name="field">Reference to Field</param>
        /// <param name="value">Value to Field</param>
        /// <param name="propertyName">Propertyname as string by CallerMemberName</param>
        /// <returns></returns>
        protected virtual bool SetPropertyValueToField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;

            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
