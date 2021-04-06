using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.ViewModels
{
    public class AccomodationsListingModel
    {
        public IEnumerable<Accomodation> Accomodations { get; set; }

        public int? AccomodationPackageID { get; set; }
        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
        public string SearchTerm { get; set; }

    }

    public class AccomodationActionModel
    {
        public int ID { get; set; }

        public int AccomodationPackageID { get; set; }
        public AccomodationPackage AccomodationPackage { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
    }
}