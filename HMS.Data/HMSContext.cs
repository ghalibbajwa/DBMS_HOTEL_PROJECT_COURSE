using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using HMS.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Data

{
    public class HMSContext : IdentityDbContext
    {
        public HMSContext() : base("HMSConnectionString")
        {
        }
        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        public static HMSContext Create()
        {
            return new HMSContext();
        }
    }
}
