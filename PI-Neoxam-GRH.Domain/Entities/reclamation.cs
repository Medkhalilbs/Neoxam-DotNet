namespace PI_Neoxam_GRH.Domain.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.reclamation")]
    public partial class reclamation
    {
        public int id { get; set; }

        public DateTime? date_creation { get; set; }

        public DateTime? date_traitement { get; set; }

        [StringLength(255)]
        public string description { get; set; }
        [StringLength(255)]
        public string objet { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? topic_id { get; set; }

        public virtual topic topic { get; set; }
    }
}
