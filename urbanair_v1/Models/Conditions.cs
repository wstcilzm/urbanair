using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanair_v1.Models
{
    /// <summary>
    /// weather con
    /// </summary>
    public class Conditions
    {
        /// <summary>
        /// weather
        /// </summary>
        public int Weather { get; set; }

        /// <summary>
        /// wind
        /// </summary>
        public int Wind { get; set; }

        /// <summary>
        /// Humidity 
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// Pressure
        /// </summary>
        public int Pressure { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        public int Temperature { get; set; }
    }
}
