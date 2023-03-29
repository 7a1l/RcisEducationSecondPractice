using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Garage.Models
{
    public partial class DriverRightsCategory
    {
        public int id_driver { get; set; }
        public int id_rights_category { get; set; }

        public virtual Driver id_driver_navigation { get; set; }
        public virtual RightsCategory id_rights_category_navigation { get; set; }
    }
}
