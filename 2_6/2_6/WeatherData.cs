using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_6
{
    class WeatherData
    {
        public Weather[] weather { get; set; }
        public Weather main { get; set; }
        public string name { get; set; }
        public Weather wind { get; set; }
        public Weather sys { get; set; }
        public string dt_txt { get; set; }
    }
}
