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
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();
            model.SearchTerm = searchTerm;

            model.AccomodationTypes = accomodationTypesServices.SearchAllAccomodationTypes(searchTerm);
            
            return View(model); 
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

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypesActionModels model = new AccomodationTypesActionModels();
          
              var accomodationType = accomodationTypesServices.GetAllAccomodationTypeByID(ID);
            model.ID = accomodationType.ID;  

        
            return PartialView("_Delete", model);

        }
        [HttpPost]
        public JsonResult Delete(AccomodationTypesActionModels model)
        {
            Console.WriteLine("cont");
            JsonResult json = new JsonResult();
            var result = false;
            var accomodationType = accomodationTypesServices.GetAllAccomodationTypeByID(model.ID);
            

            result = accomodationTypesServices.DeleteAccomodationType(accomodationType);



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