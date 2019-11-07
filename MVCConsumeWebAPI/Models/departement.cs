namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class departement
    {

        public int id { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public virtual ICollection<projet> projets { get; set; }
    }
}
