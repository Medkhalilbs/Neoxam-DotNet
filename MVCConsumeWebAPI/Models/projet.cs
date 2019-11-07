namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class projet
    {


        public int id { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public virtual ICollection<departement> departements { get; set; }
    }
}
