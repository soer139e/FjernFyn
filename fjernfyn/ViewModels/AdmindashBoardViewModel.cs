using fjernfyn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fjernfyn.ViewModels
{
    public class AdmindashBoardViewModel
    {
        public ICommand InquiryOverViewCommand { get; }
        public AdminDashBoardWindow window { get; set; }

        public AdmindashBoardViewModel()
        {
            InquiryOverViewCommand = new CommandHandler(OpenInquiryOverview);
        }

        public void OpenInquiryOverview()
        {

        }
    }
}
