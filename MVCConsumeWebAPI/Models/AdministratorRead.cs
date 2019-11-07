using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsumeWebAPI.Models
{
    public class AdministratorRead
    {

        public int id { get; set; }
        public string email { get; set; }

        
        public string login { get; set; }

        
        public string password { get; set; }

        
        public string phone_number { get; set; }

        
        public string status { get; set; }

        
        public string cin { get; set; }

        
        public string first_name { get; set; }

        
        public string last_name { get; set; }

        
        public string picture { get; set; }
        public string role { get; set; }

        public address address { get; set; }

        [JsonProperty(PropertyName = "registration_date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? registration_date { get; set; }

        public virtual IEnumerable<User_log> user_log { get; set; }

    }
}