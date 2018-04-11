using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testD.Models
{
    public class EmailFormModel
    {

        [Required(ErrorMessage = "Please enter the Name"), Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required(ErrorMessage = "Please enter the From Email"), Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Please Enter the Email Address"), Display(Name = "To email")]
        public string ToEmail { get; set; }



        [Required(ErrorMessage = "Please Type in some message")]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}
