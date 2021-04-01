﻿using System;
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
            AccomodationTypesListingModels model = new AccomodationTypesListingModels();

            model.AccomodationTypes = accomodationTypesServices.GetAllAccomodationTypes();
            return PartialView("_Listing", model.AccomodationTypes);
        }
        [HttpGet]
        public ActionResult Action()
        {
            AccomodationTypesActionModels model = new AccomodationTypesActionModels();
            Console.WriteLine("cont");
            return PartialView("_Action", model);
            
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModels model)
        {
            Console.WriteLine("cont");
            JsonResult json = new JsonResult();

            AccomodationType accomodationType = new AccomodationType();

            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;

            var result = accomodationTypesServices.SaveAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to Add Accomodation Type" };
            }

            return json;
        }

    }
}