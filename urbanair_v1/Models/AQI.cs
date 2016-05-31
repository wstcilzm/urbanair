using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// air quality index
    /// </summary>
    public class AQI
    {
        /// <summary>
        /// capture Time 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// air Pollutant
        /// </summary>
        public Pollutants AirPollutant { get; set; }
    }
}
