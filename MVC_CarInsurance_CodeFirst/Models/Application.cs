using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*the Navigation Property, which holds related entities*/

namespace MVC_CarInsurance_CodeFirst.Models
{
    public class Application
    {

        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public int QuoteID { get; set; }

        public virtual Quote Quote { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}