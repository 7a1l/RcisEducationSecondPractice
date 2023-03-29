using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class RightsCategory
    {
        public RightsCategory()
        {
            driver_rights_categories = new HashSet<DriverRightsCategory>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<DriverRightsCategory> driver_rights_categories { get; set; }
    }
}
