using MVC_CarInsurance_CodeFirst.Models;
using System;
using System.Collections.Generic;

/*creates and initializes the database with default entries*/

namespace MVC_CarInsurance_CodeFirst.DAL
{
    public class InsuranceInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<InsuranceContext>
    {
        protected override void Seed(InsuranceContext context)
        {
            var applicants = new List<Applicant>
            {
                new Applicant{FirstName="Levi", LastName="Blodgett", EmailAddress="LeviB@hotmail.com", DateOfBirth=DateTime.Parse("1997-11-02"), CarYear=2002, CarMake="Ford", CarModel="Taurus", DUI=false, SpeedingTickets=0, Coverage=true, Quote=0},
                new Applicant{FirstName="Arjuna", LastName="Guatama", EmailAddress="Quinnico@gmail.com", DateOfBirth=DateTime.Parse("1990-05-10"), CarYear=1998, CarMake="General Motors", CarModel="Cadillac", DUI=false, SpeedingTickets=1, Coverage=false, Quote=0}
            };
            /*specifies the Quote prices for each applicant in the initializer*/
            for (int i = 0; i < applicants.Count; i++)
            {
                applicants[i].Quote = applicants[i].GenerateQuote(applicants[i]);
            }
            applicants.ForEach(s => context.Applicants.Add(s));
            context.SaveChanges();
        }
    }
}