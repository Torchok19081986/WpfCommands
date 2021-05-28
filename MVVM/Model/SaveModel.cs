using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCommands.Base;

namespace WpfCommands.MVVM.Model
{
    public class SaveModel : BindingBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetPropertyValueToField(ref _name, value, nameof(Name));
        }

        private string _vorname;

        public string Vorname
        {
            get => _vorname;
            set => SetPropertyValueToField(ref _vorname, value, nameof(Vorname));
        }
        private int _age;

        public int Age
        {
            get => _age;
            set => SetPropertyValueToField(ref _age, value, nameof(Age));

        }

        private string _country;

        public string Country
        {
            get => _country;
            set => SetPropertyValueToField(ref _country, value, nameof(Country));
        }

    }
}
