using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace LoadWeatherDataToRedis
{
    [RunInstaller(true)]
    public partial class LoadWeatherDataServiceInstaller : System.Configuration.Install.Installer
    {
        public LoadWeatherDataServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
