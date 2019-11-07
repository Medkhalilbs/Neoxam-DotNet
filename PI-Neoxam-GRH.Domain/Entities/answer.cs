namespace PI_Neoxam_GRH.Domain.Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.answer")]
    public partial class answer
    {
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool juste { get; set; }

        [StringLength(255)]
        public string type_reponse { get; set; }

        public int? question_id { get; set; }

        public virtual question question { get; set; }

        public override string ToString()
        {
            return "Answer: id=" + id + ", juste=" + juste + ", reponse=" + type_reponse;
        }
    }
}
