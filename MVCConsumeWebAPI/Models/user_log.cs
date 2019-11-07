namespace MVCConsumeWebAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class User_log
    {
   
        public int id { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string ip_address { get; set; }

        [JsonProperty(PropertyName = "login_timestamp")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? login_timestamp { get; set; }

        [JsonProperty(PropertyName = "logout_timestamp")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? logout_timestamp { get; set; }

        [StringLength(255)]
        public string pc_id { get; set; }

        [StringLength(255)]
        public string session_id { get; set; }

        public int? user_id { get; set; }

        public virtual User user { get; set; }
    }
}
