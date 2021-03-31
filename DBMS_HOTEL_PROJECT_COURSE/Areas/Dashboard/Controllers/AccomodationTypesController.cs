using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Services;
using HMS.Entities;
using DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.ViewModels;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.Controllers
{
    
    public class AccomodationTypesController : Controller
    {
        AccomodationTypesServices accomodationTypesServices = new AccomodationTypesServices();
        public ActionResult Index()
        {
            return View(); 
        }

       public ActionResult Listing()
        {
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();

            model.AccomodationTypes = accomodationTypesServices.GetAllAccomodationTypes();


            return PartialView("_Listing", model);
        }
        public ActionResult Action()
        {
            AccomodationTypesActionModels model = new AccomodationTypesActionModels();
            return PartialView("_Action");
        }

    }
}