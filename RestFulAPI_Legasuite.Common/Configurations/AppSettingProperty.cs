using Newtonsoft.Json;
using RestFulAPI_Legasuite.Common.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Common.Model
{
    public class AppSettingProperty
    {

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string JDESystem { get; set; }
        public string NonJDESystem { get; set; }

        public Library Library { get; set; }
    }



    public class Library
    {
        public string JDE { get; set; }
        public string WCS { get; set; }
        public string SPOOL { get; set; }
    }

    public class UpdatePasswordInputs
    {        
        public string system { get; set; }
        public string newPassword { get; set; }
        public string siteName { get; set; }

    }
}
