namespace PI_Neoxam_GRH.Domain.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.evalutaiontest")]
    public partial class evalutaiontest
    {
        [Key]
        [StringLength(255)]
        public string Department { get; set; }

        [StringLength(255)]
        public string Deadline { get; set; }

        [StringLength(255)]
        public string Title { get; set; }
    }
}
