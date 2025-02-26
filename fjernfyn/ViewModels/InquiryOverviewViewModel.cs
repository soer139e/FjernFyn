using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fjernfyn.Repositories;
using fjernfyn.Classes;
namespace fjernfyn.viewmodels
{
    public class InquiryOverviewViewModel
    {
        public List<Feedback> Feedbacks { get; set; }
        private FeedbackRepo feedbackRepo;
        
        public Category Categorys;
        public List<Priority> Prioritys { get; set; }
        public List<Software> Softwares { get; set; }
        
        public InquiryOverviewViewModel()
        {
            Feedbacks = new List<Feedback>();
            feedbackRepo = new FeedbackRepo();

            //Feedbacks = feedbackRepo.GetAllFeedback();
            Prioritys = new List<Priority>();
            Prioritys.Add(Priority.High);
            Prioritys.Add(Priority.Medium);
            Prioritys.Add(Priority.Low);


            Feedbacks.Add(new Feedback()
            {
                Title = "Hjælp der ild i lokumet",
                CreationDate = "01:12:1939",
                Type = 0,
                Priority = 0,
                SoftwareProp = new Software() { Name = "Excel"},
                
            });
            Feedbacks.Add(new Feedback()
            {
                Title = "Hjælp der ild i birk",
                CreationDate = "01:12:1939",
                Type = 0,
                Priority = Priority.Low,
                SoftwareProp = new Software() { Name = "janitor software" },

            });


        }
    }
}
