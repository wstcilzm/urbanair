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
