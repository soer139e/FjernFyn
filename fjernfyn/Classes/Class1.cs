using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace fjernfyn
{
    public class GlobalValues
    {
        private static Employee _currentEmployee;

        public Employee CurrentEmployee { get { return _currentEmployee; } set { _currentEmployee = value; }  }

    }

}
