using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// City entity info
    /// </summary>
    public class City
    {
        /// <summary>
        /// city id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// located province
        /// </summary>
        public string ProvinceId { get; set; }

        /// <summary>
        /// city chinese name
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// city english name
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
        /// district id list
        /// </summary>
        public IEnumerable<string> DistrictIdList { get; set; }


    }
}
