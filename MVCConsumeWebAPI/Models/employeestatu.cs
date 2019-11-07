namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class employeestatu
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cin { get; set; }

        [StringLength(255)]
        public string Carrer_interview { get; set; }

        [StringLength(255)]
        public string Department { get; set; }

        [StringLength(255)]
        public string Evalutaion { get; set; }

        [StringLength(255)]
        public string Job { get; set; }

        public int N1 { get; set; }

        [StringLength(255)]
        public string employee_name { get; set; }

        [StringLength(255)]
        public string team_leader { get; set; }
    }
}
