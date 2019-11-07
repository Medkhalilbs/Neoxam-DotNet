namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class employee
    {
  
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Recrutment_date { get; set; }

        public int Salary { get; set; }

        public int bonus_pts { get; set; }

        public int childrens_nbr { get; set; }

        [StringLength(255)]
        public string mail { get; set; }

        public int nbr_holidays { get; set; }

        public int nbr_late { get; set; }

        [StringLength(255)]
        public string position_held { get; set; }
    }
}
