using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CarInsurance_CodeFirst.Models
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuoteID { get; set; }
        public float QuotePrice { get; set; }

        public Quote(int id, Applicant app)
        {
            QuoteID = id;
            QuotePrice = GenerateQuote(app);
        }

        public virtual ICollection<Application> Applications { get; set; }

        /*generates an insurance quote based on applicants info*/
        public float GenerateQuote(Applicant app)
        {
            float price = 50;
            DateTime present = DateTime.Now;

            /*if the applicant is under 25 but above 18, add 25 dollars to the monthly total*/
            if ((present.Year - app.DateOfBirth.Year) < 25 && (present.Year - app.DateOfBirth.Year) > 18)
            {
                price += 25;
            }
            /*if the applicant is under 18, add 100 dollars to the monthly total*/
            else if ((present.Year - app.DateOfBirth.Year) < 18)
            {
                price += 100;
            }

            /*if the applicants car was made before 2000, add 25 dollars to the monthly total*/
            if (app.CarYear < 2000)
            {
                price += 25;
            }
            /*if the car was made after 2015, add 25 dollars*/
            if (app.CarYear > 2015)
            {
                price += 25;
            }

            /*if car is a Porsche, add 25 dollars*/
            if (app.CarMake == "Porsche")
            {
                price += 25;

                /*if car is a Porsche and a 911 Carrera, add 25 dollars*/
                if (app.CarModel == "911 Carrera")
                {
                    price += 25;
                }
            }

            /*add 10 dollars per speeding ticket*/
            for (int i = 0; i < app.SpeedingTickets; i++)
            {
                price += 10;
            }

            /*if applicant has a DUI, add 25 percent of the current price to the total*/
            if (app.DUI == true)
            {
                price += (price / 4);
            }

            /*if the applicant wants full coverage, add 50 percent of the current price to the total*/
            if (app.Coverage == true)
            {
                price += (price / 2);
            }

            return price;
        }
    }
}