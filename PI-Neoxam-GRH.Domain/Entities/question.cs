namespace PI_Neoxam_GRH.Domain.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.question")]
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            answer = new HashSet<answer>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string complexity { get; set; }

        [StringLength(255)]
        public string enonce { get; set; }

        [StringLength(255)]
        public string indice { get; set; }

        public double point { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? topic_id { get; set; }

        [StringLength(255)]
        public string reponsejuste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answer> answer { get; set; }

        public virtual topic topic { get; set; }
    }
}
