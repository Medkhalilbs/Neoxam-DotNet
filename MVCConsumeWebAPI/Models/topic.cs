namespace MVCConsumeWebAPI.Models
{
    
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class topic
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public topic()
        //{
        //    questions = new HashSet<question>();
        //}

        public int id { get; set; }

        public int dureeTopic { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public int nombre_question { get; set; }

      //  public int domain_id { get; set; }
        public virtual Domain domain { get; set; }
        [JsonIgnore]
        public virtual ICollection<Models.result> result { get; set; }


        [JsonIgnore]
        public virtual IEnumerable<question> questions { get; set; }

    }
}
