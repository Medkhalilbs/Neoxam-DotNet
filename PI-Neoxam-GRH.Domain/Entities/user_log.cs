namespace PI_Neoxam_GRH.Domain.Enities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.user_log")]
    public partial class user_log
    {
        public int id { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string ip_address { get; set; }

        public DateTime? login_timestamp { get; set; }

        public DateTime? logout_timestamp { get; set; }

        [StringLength(255)]
        public string pc_id { get; set; }

        [StringLength(255)]
        public string session_id { get; set; }

        public int? user_id { get; set; }

        public virtual user user { get; set; }
    }
}
