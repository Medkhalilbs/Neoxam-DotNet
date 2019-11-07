namespace PI_Neoxam_GRH.Domain.Enities
{ 

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.t_critere")]
    public partial class t_critere
    {
        [Key]
        public int idCritere { get; set; }

        [StringLength(255)]
        public string DescrCritere { get; set; }

        public int Pourcentage { get; set; }

        public int? admin_id { get; set; }

        public virtual user user { get; set; }
    }
}
