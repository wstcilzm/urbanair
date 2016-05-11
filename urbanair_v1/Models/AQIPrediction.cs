using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// air quality index prediction
    /// </summary>
    public class AQIPrediction
    {
        /// <summary>
        /// request time
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// pollutant name
        /// </summary>
        public string PollutantName { get; set; }

        /// <summary>
        /// pollutant values range
        /// </summary>
        public IEnumerable<int> PreditionValues { get; set; }

        /// <summary>
        /// next 48 hours prediction values
        /// </summary>
        public IEnumerable<PredictionRange> PRange { get; set; }
        
    }

    /// <summary>
    /// prediction time range
    /// </summary>
    public class PredictionRange
    {
        /// <summary>
        /// prediction start hour
        /// </summary>
        public int StartHour { get; set; }

        /// <summary>
        /// prediction end hour
        /// </summary>
        public int EndHour { get; set; }

        /// <summary>
        /// prediction min air quality index
        /// </summary>
        public int MinAQI { get; set; }

        /// <summary>
        /// prediction max air quality index
        /// </summary>
        public int MaxAQI { get; set; }
    }
}
