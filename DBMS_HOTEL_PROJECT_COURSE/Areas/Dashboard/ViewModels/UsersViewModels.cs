using HMS.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_HOTEL_PROJECT_COURSE.Areas.Dashboard.ViewModels
{

        public class UsersListingModel
        {
            public IEnumerable<HMSUser> Users { get; set; }

            public string? RoleID { get; set; }
            public IEnumerable<IdentityRole> Roles { get; set; }
            public string SearchTerm { get; set; }

        }

        public class UserActionModel
        {
            public int ID { get; set; }

            public string RoleID { get; set; }
            public IdentityRole Role { get; set; }

            public string Name { get; set; }

            public IEnumerable<IdentityRole> Roles { get; set; }
        }
    
}