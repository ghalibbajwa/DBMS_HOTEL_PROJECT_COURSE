using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Entities;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.ViewModels
{
    public class AccomodationTypesListingModels
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
        public string SearchTerm { get;set; }
    }
    public class AccomodationTypesActionModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}