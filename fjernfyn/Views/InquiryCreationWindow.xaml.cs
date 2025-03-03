using System.Windows;
using System.Windows.Controls;

namespace fjernfyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FeedbackCreationWindow : Window
    {
        public InquiryCreateViewModel viewModel {  get; set; }
        //private Employee Employee { get; set; }

        public FeedbackCreationWindow(Employee emp)
        {
            InitializeComponent();
           // Employee = emp;
            viewModel = new InquiryCreateViewModel(this, emp);
            DataContext = viewModel;
        }

       

    }
}