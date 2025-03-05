using System.Windows;
using System.Windows.Controls;

namespace fjernfyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FeedbackCreationWindow : Window
    {
        public FeedbackCreateViewModel viewModel {  get; set; }
        //private Employee Employee { get; set; }

        public FeedbackCreationWindow(Employee emp)
        {
            InitializeComponent();
           // Employee = emp;
            viewModel = new FeedbackCreateViewModel(this, emp);
            DataContext = viewModel;
        }

        private void tbUName_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(viewModel.Feedback.Title == "Titel")
            {
                viewModel.Feedback.Title = "";
            }
        }
    }
}