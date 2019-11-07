using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsumeWebAPI.Models
{
    public class address
    {
 // public double Lat { get; set; }
            //  public double Lng { get; set; }

            //house_number
            public string addressLine1 { get; set; }

            //street
            public string addressLine2 { get; set; }

            public string city { get; set; }
            public string country { get; set; }

            public string state { get; set; }

            public string zipCode { get; set; }

            public double lat { get; set; }
            public double lng { get; set; }
            public string markerColor { get; set; }
    }
}