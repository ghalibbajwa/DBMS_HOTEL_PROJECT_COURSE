using DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.Controllers
{
    public class AccomodationsController : Controller
    {
        AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
        AccomodationService accomodationsService = new AccomodationService();

        public ActionResult Index(string searchTerm, int? accomodationPackageID, int? page)
        {

            AccomodationsListingModel model = new AccomodationsListingModel();

            model.SearchTerm = searchTerm;
            model.AccomodationPackageID = accomodationPackageID;
            model.AccomodationPackages = accomodationPackagesService.GetAllAccomodationPackages();

            model.Accomodations = accomodationsService.SearchAccomodations(searchTerm, accomodationPackageID);
            

            

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationActionModel model = new AccomodationActionModel();

            if (ID.HasValue) //we are trying to edit a record
            {
                var accomodation = accomodationsService.GetAccomodationByID(ID.Value);

                model.ID = accomodation.ID;
                model.AccomodationPackageID = accomodation.AccomodationPackageID;
                model.Name = accomodation.Name;
                model.Description = accomodation.Description;
            }

            model.AccomodationPackages = accomodationPackagesService.GetAllAccomodationPackages();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0) //we are trying to edit a record
            {
                var accomodation = accomodationsService.GetAccomodationByID(model.ID);

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;

                result = accomodationsService.UpdateAccomodation(accomodation);
            }
            else //we are trying to create a record
            {
                HMS.Entities.Accomodation accomodation = new HMS.Entities.Accomodation();

                accomodation.AccomodationPackageID = model.AccomodationPackageID;
                accomodation.Name = model.Name;
                accomodation.Description = model.Description;

                result = accomodationsService.SaveAccomodation(accomodation);
            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation." };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationActionModel model = new AccomodationActionModel();

            var accomodation = accomodationsService.GetAccomodationByID(ID);

            model.ID = accomodation.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodation = accomodationsService.GetAccomodationByID(model.ID);

            result = accomodationsService.DeleteAccomodation(accomodation);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation." };
            }

            return json;
        }
    }
}