namespace MVCConsumeWebAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class Domain
    {
      
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public string type { get; set; }


        //[JsonProperty("topics")]
        //public List<topic> topics { get; set; }
    }
}
