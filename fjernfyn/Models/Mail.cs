using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fjernfyn.Models
{
    public class Mail
    {
        public string Sender { get; set; }
        public string Reciver {  get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Mail() { }
    }
}
