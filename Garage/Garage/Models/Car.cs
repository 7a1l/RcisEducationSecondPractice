using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class Car
    {
        public Car()
        {
            Routes = new HashSet<Route>();
        }

        public int id { get; set; }
        public int id_type_car { get; set; }
        public string name { get; set; }
        public string state_number { get; set; }
        public int number_passengers { get; set; }

        public virtual TypeCar type_car { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
