namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class project
    {
        public int id { get; set; }

        public int Duration { get; set; }

        [StringLength(255)]
        public string Topic { get; set; }

        public DateTime? dateProject { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? cv5_id { get; set; }

        public virtual cv cv { get; set; }
    }
}
