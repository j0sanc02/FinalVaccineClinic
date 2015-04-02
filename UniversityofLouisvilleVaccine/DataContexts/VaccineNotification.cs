using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class VaccineNotificationDB : DbContext
    {
        public VaccineNotificationDB()
            : base("DefaultConnection")
        {

        }
        public DbSet<VaccineNotification> VaccineNotifications { get; set; }
    }
}