using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestSample.Core.Settings
{
    public class AppSettings
    {
        public static int PageListLength
        {
            get
            {
                return ConfigurationManager.AppSettings["PageListLength"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["PageListLength"]) : 15;
            }
        }
    }
}