using System;
using System.Collections.Generic;

#nullable disable

namespace Garage.Models
{
    public partial class TypeCar
    {
        public TypeCar()
        {
            Cars = new HashSet<Car>();
        }

        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
