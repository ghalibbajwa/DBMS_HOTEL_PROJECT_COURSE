using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.Services
{
   public class AccomodationService
    {
        public IEnumerable<Entities.Accomodation> GetAllAccomodations()
        {
            var context = new HMSContext();

            return context.Accomodations.ToList();
        }

        public IEnumerable<Entities.Accomodation> GetAllAccomodationsByAccomodationPackage(int accomodationPackageID)
        {
            var context = new HMSContext();

            return context.Accomodations.Where(x => x.AccomodationPackageID == accomodationPackageID).ToList();
        }

        public IEnumerable<Entities.Accomodation> SearchAccomodations(string searchTerm, int? accomodationPackageID)
        {
            var context = new HMSContext();

            var accomodations = context.Accomodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodations = accomodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
            {
                accomodations = accomodations.Where(a => a.AccomodationPackageID == accomodationPackageID.Value);
            }



            return accomodations.ToList();
        }

        public int SearchAccomodationsCount(string searchTerm, int? accomodationPackageID)
        {
            var context = new HMSContext();

            var accomodations = context.Accomodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodations = accomodations.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
            {
                accomodations = accomodations.Where(a => a.AccomodationPackageID == accomodationPackageID.Value);
            }

            return accomodations.Count();
        }

        public Accomodation GetAccomodationByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.Accomodations.Find(ID);
            }
        }

        public bool SaveAccomodation(Entities.Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Accomodations.Add(accomodation);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodation(Entities.Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Entry(accomodation).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodation(Entities.Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Entry(accomodation).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
