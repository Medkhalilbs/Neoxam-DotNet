namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class skill
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Level { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        public int? cv6_id { get; set; }

        public virtual cv cv { get; set; }
    }
}
