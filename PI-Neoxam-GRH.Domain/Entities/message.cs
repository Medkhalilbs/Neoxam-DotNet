namespace PI_Neoxam_GRH.Domain.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.messages")]
    public partial class message
    {
        public int id { get; set; }

        
        public string contenu { get; set; }

        public DateTime? dateEnvoie { get; set; }

        public DateTime? dateLecture { get; set; }

        [StringLength(255)]
        public string destinataire { get; set; }

        [StringLength(255)]
        public string statusMessage { get; set; }

        [StringLength(255)]
        public string sujet { get; set; }

        [StringLength(255)]
        public string visibiliteMessage { get; set; }

     
        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
