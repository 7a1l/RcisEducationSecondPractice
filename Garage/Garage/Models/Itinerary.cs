using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class Itinerary
    {
        public Itinerary()
        {
            Routes = new HashSet<Route>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
