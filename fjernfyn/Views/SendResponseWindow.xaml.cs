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
using fjernfyn.Classes;

namespace fjernfyn.Views
{
    /// <summary>
    /// Interaction logic for SendResponseWindow.xaml
    /// </summary>
    public partial class SendResponseWindow : Window
    {
        SendResponseViewModel SRVM { get; set; }
        public SendResponseWindow(Feedback inquiry)
        {
            InitializeComponent();
            SRVM = new  SendResponseViewModel(inquiry);
            DataContext = SRVM;
        }
    }
}
