using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Listing()
        {
            //var accomodationTypes = 

            return PartialView("_Listing");
        }
    }
}