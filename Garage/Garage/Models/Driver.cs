using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class Driver
    {
        public Driver()
        {
            driver_rights_categories = new HashSet<DriverRightsCategory>();
            Routes = new HashSet<Route>();
        }

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }

        public virtual ICollection<DriverRightsCategory> driver_rights_categories { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
