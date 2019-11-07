namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class formation
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Certification { get; set; }

        public DateTime? End_Date { get; set; }

        public DateTime? Start_Date { get; set; }

        [StringLength(255)]
        public string addressLine1 { get; set; }

        [StringLength(255)]
        public string addressLine2 { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string zipCode { get; set; }

        public int duration { get; set; }

        public int? cv2_id { get; set; }

        public virtual cv cv { get; set; }
    }
}
