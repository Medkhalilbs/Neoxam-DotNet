namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class hoby
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Level { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Place { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public int? cv3_id { get; set; }

        public virtual cv cv { get; set; }
    }
}
