using Postal;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.DataContexts;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.ScheduledTasks
{
    public class EmailJob:IJob

    {
        public void Execute (IJobExecutionContext context)
        {
            VaccineDBContext vb3 = new VaccineDBContext();
            
 
            var dosesum =
                (from vb in vb3.Vaccines
                 where vb.vaccineID == vb.vaccineID
                 select vb.numofDoses).Sum();

            var avgwarning =
                (from VDB in vb3.Vaccines
                 where VDB.vaccineID == VDB.vaccineID
                 select VDB.inventoryWarning).Average();
            
            
            dynamic email = new Email("Warning");
            email.To = "j0sanc02@gmail.com";
            email.Send();

        }

    }
}