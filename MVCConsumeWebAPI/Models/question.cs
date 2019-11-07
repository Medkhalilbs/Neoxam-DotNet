namespace MVCConsumeWebAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class question
    {


        public int id { get; set; }

        [StringLength(255)]
        public string complexity { get; set; }

        [StringLength(255)]
        public string enonce { get; set; }

        [StringLength(255)]
        public string indice { get; set; }

        public double point { get; set; }

        //[StringLength(255)]
        //public string type { get; set; }

      //  public int? topic_id { get; set; }

        [StringLength(255)]
        public string reponsejuste { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<answer> answers { get; set; }
        //[JsonIgnore]
        public virtual topic topic { get; set; }
    }
}
