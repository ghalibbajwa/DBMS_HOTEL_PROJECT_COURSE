using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.Services
{
    public class AccomodationTypesServices
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();

            return context.AccomodationTypes.AsEnumerable() ;
        }
    }
}
