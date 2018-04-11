using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace testD.Models
{
    public class EmailAndCustomer
    {
        private Database1Entities db = new Database1Entities();


        public Customer customer { get; set; }

        public List<Customer> customers { get; set; }

        public EmailFormModel emailFormModel { get; set; }

    }
}