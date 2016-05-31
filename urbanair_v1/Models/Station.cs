using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;

namespace urbanair_v1.Models
{
    /// <summary>
    /// station info
    /// </summary>
    public class Station
    {
        /// <summary>
        /// station id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// located district id
        /// </summary>
        public string DistrictId { get; set; }

        /// <summary>
        /// station chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// station english name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// station latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// station longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Represents a geography point of station.
        /// </summary>
        public DbGeography StationGeo { get; set; }
    }
}
