using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Services
{
    public class AccomodationTypesServices
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();

            return context.AccomodationTypes.ToList() ;
        }

        public AccomodationType GetAllAccomodationTypeByID(int ID)
        {
            var context = new HMSContext();

            return context.AccomodationTypes.Find(ID);
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.AccomodationTypes.Add(accomodationType);

            return context.SaveChanges() > 0;
        }


        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }
        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }

        public IEnumerable<AccomodationType> SearchAllAccomodationTypes(string searchTerm)
        {
            var context = new HMSContext();
            var accomodationTypes = context.AccomodationTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationTypes= accomodationTypes.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accomodationTypes.ToList();
        }

    }
}
