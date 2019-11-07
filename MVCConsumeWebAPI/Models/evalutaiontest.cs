namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class evalutaiontest
    {

        [StringLength(255)]
        public string Department { get; set; }

        [StringLength(255)]
        public string Deadline { get; set; }

        [StringLength(255)]
        public string Title { get; set; }
    }
}
