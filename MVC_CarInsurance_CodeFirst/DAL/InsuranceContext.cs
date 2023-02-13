using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_CarInsurance_CodeFirst.Models;

namespace MVC_CarInsurance_CodeFirst.DAL
{
    public class InsuranceContext : DbContext
    {

        /*default constructor, which has the database connection string passed to it*/
        public InsuranceContext() : base("InsuranceContext")
        {
        }

        /*these are Entity Sets, which correspond to a table in the database*/
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removes pluralization from the names of the tables if the EntitySets are already pluralized
            //(for example, it will name the table "Applicants" instead of "Applicantss"
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}