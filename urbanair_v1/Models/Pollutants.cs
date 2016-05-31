using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// Pollutants
    /// </summary>
    public class Pollutants
    {
        /// <summary>
        /// PM2.5 index for air quality
        /// </summary>
        public int PM25 { get; set; }

        /// <summary>
        /// PM10 index for air quality
        /// </summary>
        public int PM10 { get; set; }

        /// <summary>
        /// NO2 index for air quality
        /// </summary>
        public int NO2 { get; set; }

        /// <summary>
        /// CO index for air quality
        /// </summary>
        public int CO { get; set; }

        /// <summary>
        /// O3 index for air quality
        /// </summary>
        public int O3 { get; set; }

        /// <summary>
        /// SO2 index for air quality
        /// </summary>
        public int SO2 { get; set; }
    }
}
