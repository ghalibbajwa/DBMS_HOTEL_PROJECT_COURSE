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
        [HttpGet]
        public ActionResult Listing()
        {
            System.Diagnostics.Debug.WriteLine("This is a log");
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();

            model.AccomodationTypes = accomodationTypesServices.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypesActionModels model = new AccomodationTypesActionModels();
            if (ID.HasValue) //for editing
            {
                var accomodationType = accomodationTypesServices.GetAllAccomodationTypeByID(ID.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
            
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModels model)
        {
            Console.WriteLine("cont");
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID>0) //edit
            {
                var accomodationType = accomodationTypesServices.GetAllAccomodationTypeByID(model.ID);
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesServices.UpdateAccomodationType(accomodationType);
                
            }
            else { //create

                AccomodationType accomodationType = new AccomodationType();

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesServices.SaveAccomodationType(accomodationType);
            }

           

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Action Failed" };
            }

            return json;
        }

    }
}