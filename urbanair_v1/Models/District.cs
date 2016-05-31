using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;

namespace urbanair_v1.Models
{
    /// <summary>
    /// distirct info
    /// </summary>
    public class District
    {
        /// <summary>
        /// district id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// located city id
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// district Chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// district English name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Represents a geography shapes of district.
        /// </summary>
        public DbGeography DistrictGeo { get; set; }

        /// <summary>
        /// station id list
        /// </summary>
        public IEnumerable<string> StationIdList{ get; set; }
    }
}
