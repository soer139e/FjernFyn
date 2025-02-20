namespace fjernfyn
{
    public class GlobalValues
    {
        private static Employee _currentEmployee;

        public Employee CurrentEmployee { get { return _currentEmployee; } set { _currentEmployee = value; }  }

    }

}
