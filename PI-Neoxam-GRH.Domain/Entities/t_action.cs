namespace PI_Neoxam_GRH.Domain.Enities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.t_action")]
    public partial class t_action
    {
        [Key]
        public int idAction { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public double pourcentage { get; set; }

        public int? type { get; set; }

        public int? admin_id { get; set; }

        public virtual user user { get; set; }
    }
}
