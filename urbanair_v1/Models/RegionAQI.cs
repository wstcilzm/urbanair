using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// region air quality index
    /// </summary>
    public class RegionAQI
    {
        /// <summary>
        /// capture Time 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// air Pollutants
        /// </summary>
        public Pollutants AirPollutants { get; set; }

        /// <summary>
        /// bottom latitude
        /// </summary>
        public double BottomLatitude { get; set; }

        /// <summary>
        /// up latitude
        /// </summary>
        public double UpLatitude { get; set; }

        /// <summary>
        /// left longtitude
        /// </summary>
        public double LeftLongtitude { get; set; }

        /// <summary>
        /// right longtitude
        /// </summary>
        public double RightLongtitude { get; set; }
    }
}
