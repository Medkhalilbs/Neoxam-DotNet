namespace PI_Neoxam_GRH.Domain.Enities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("neoxamdb.users")]
    public partial class user 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            cvs = new HashSet<cv>();
            messages = new HashSet<message>();
            t_action = new HashSet<t_action>();
            t_critere = new HashSet<t_critere>();
            user_log = new HashSet<user_log>();
            result = new HashSet<result>();
        }

        [Required]
        [StringLength(31)]
        public string role { get; set; }


        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        public DateTime? registration_date { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string house_number { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string state { get; set; }

        [StringLength(255)]
        public string zipCode { get; set; }

        [StringLength(255)]
        public string markerColor { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        public int? Age { get; set; }

        public double? lat { get; set; }

        public double? lng { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string DriverLience { get; set; }

    
        public int? ProfilValide { get; set; }

        [StringLength(255)]
        public string SocialState { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string Birthdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cv> cvs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_action> t_action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_critere> t_critere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_log> user_log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> result { get; set; }
    }
}
