using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// province info
    /// </summary>
    public class Province
    {
        /// <summary>
        /// province id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// province chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// province english name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// bottom latitude
        /// </summary>
        public double BottomLatitude { get; set; }

        /// <summary>
        /// up latitude
        /// </summary>
        public double UpLatitude { get; set; }

        /// <summary>
        /// left longitude
        /// </summary>
        public double LeftLongitude { get; set; }

        /// <summary>
        /// right longitude
        /// </summary>
        public double RightLongitude { get; set; }

        /// <summary>
        /// center latitude
        /// </summary>
        public double CenterLatitude { get; set; }

        /// <summary>
        /// center longitude
        /// </summary>
        public double CenterLongitude { get; set; }

        /// <summary>
        /// city id list
        /// </summary>
        public IEnumerable<string> CityIdList { get; set; }
    }
}
