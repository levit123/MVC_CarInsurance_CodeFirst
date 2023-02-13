using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CarInsurance_CodeFirst.Models
{
    public class Applicant
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public bool Coverage { get; set; }
        public float Quote { get; set; }

        /*generates an insurance quote based on applicants info*/
        //Method to calculate the value of the "Quote" property based on info the user inputted in the "Create.cshtml" form.
        //This method will be called in the POST "Create" method, and will save it's returned value to the "Quote" property
        //of the Applicant object used in that POST method. It will also be called when initializing the database
        //with starting objects
        public float CalculateQuote(Applicant applicant)
        {
            //starts the Quote price at a base of 50 dollars
            float result = 50;

            //calculates the applicant's age in years by subtracting their year of birth from the current year
            int age = DateTime.Now.Year - applicant.DateOfBirth.Year;

            //if the applicant is under 18, increase the quote price by 100 dollars
            if (age < 18)
            {
                result += 100;
            }
            //otherwise, if the applicant is over 18 but under 25, increase the quote price by 50 dollars
            else if (age >= 18 && age < 25)
            {
                result += 50;
            }

            //if the applicant's car was manufactured before the year 2000, increase the quote price by 50 dollars
            if (applicant.CarYear < 2000)
            {
                result += 50;
            }
            //otherwise, if the applicant's car was manufactured after the year 2015, increase the quote price by 25 dollars
            else if (applicant.CarYear > 2015)
            {
                result += 25;
            }

            //if the applicant has a DUI, increase the quote price by 50 percent
            if (applicant.DUI == true)
            {
                result *= 1.50f;
            }

            //if the applicant wants full coverage, increase the quote price by 25 percent
            if (applicant.Coverage == true)
            {
                result *= 1.25f;
            }

            //increase the quote price by 10 dollars per speeding ticket they have. If they dont have any speeding tickets,
            //it will not increase the price
            result += applicant.SpeedingTickets * 10;

            //return the calculate quote price
            return result;
        }

        /*this is a Navigation Property, which holds related entities (in this case, the Quote entity)
        public virtual ICollection<Application> Applications { get; set; }
        */
    }
}