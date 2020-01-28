using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CarInsurance_CodeFirst.DAL;
using MVC_CarInsurance_CodeFirst.Models;

namespace MVC_CarInsurance_CodeFirst.Controllers
{
    public class AdminController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }
    }
}