using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class Route
    {
        public int id { get; set; }
        public int id_driver { get; set; }
        public int id_car { get; set; }
        public int id_itinerary { get; set; }
        public int number_passengers { get; set; }

        public virtual Car idCarNavigation { get; set; }
        public virtual Driver id_driver_navigation { get; set; }
        public virtual Itinerary id_itinerary_navigation { get; set; }
    }
}
