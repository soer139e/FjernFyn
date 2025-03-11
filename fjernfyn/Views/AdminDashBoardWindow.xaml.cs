using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using fjernfyn.ViewModels;

namespace fjernfyn.Views
{
    /// <summary>
    /// Interaction logic for AdminDashBoardWindow.xaml
    /// </summary>
    public partial class AdminDashBoardWindow : Window
    {
        private Employee _employee { get; set; }
        public AdminDashBoardViewModel adbvw { get; set; }
 
        public AdminDashBoardWindow(Employee employee)
        {
            InitializeComponent();
            adbvw = new AdminDashBoardViewModel(this, _employee);
            _employee = employee;
        }
    }
}
