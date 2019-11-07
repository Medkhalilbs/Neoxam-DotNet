namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class result
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column("result")]
        [StringLength(255)]
        public string result1 { get; set; }

        public double score { get; set; }

        [StringLength(255)]
        public string statut { get; set; }

        public int topicid { get; set; }
        [ForeignKey("topicid")]
        public topic topic { get; set; }
        //public int candidateid { get; set; }
        //[ForeignKey("candidateid")]
      //  public user user { get; set; }
    }
}
