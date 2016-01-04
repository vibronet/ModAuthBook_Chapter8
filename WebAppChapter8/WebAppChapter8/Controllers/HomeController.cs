using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebAppChapter8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            string userfirstname = ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value;
            // if you want to play with roles, make sure you uncomment the right RoleClaimType assignment in startup.auth.cs
            //if (ClaimsPrincipal.Current.IsInRole("approver"))
            //{
            ViewBag.Message = String.Format("Welcome, {0}!", userfirstname);
            //}
            //else
            //    ViewBag.Message = String.Format("User {0} is not an approver", userfirstname);
            return View();
        }
    }
}