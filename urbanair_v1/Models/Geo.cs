using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// city geo info
    /// </summary>
    public class CityGeo 
    {
        /// <summary>
        /// city id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// city chinese name
        /// </summary>
        public string ChineseName { get; set; }


        /// <summary>
        /// city englishName
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// station infos
        /// </summary>
        public IEnumerable<Station> Stations { get; set; }
    }
}
