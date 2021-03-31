using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using HMS.Entities;

namespace HMS.Data

{
    public class HMSContext : DbContext
    {
        public HMSContext() : base("HMSConnectionString")
        {
        }
        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
