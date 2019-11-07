//namespace MVCConsumeWebAPI.Models
//{
//    using Newtonsoft.Json;
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

 
//    public partial class User
//    {
        
     

//        [StringLength(255)]

//        public string Subject { get; set; }

      
//        public int id { get; set; }

//        [Required]
//        [StringLength(255)]
//        public string email { get; set; }

//        [StringLength(255)]
//        public string login { get; set; }

//        [StringLength(255)]
//        public string password { get; set; }

//        [StringLength(255)]
//        public string phone_number { get; set; }

//        [JsonProperty(PropertyName = "registration_date")]
//        [JsonConverter(typeof(CustomDateTimeConverter))]
//        public DateTime? registration_date { get; set; }

//        [StringLength(255)]
//        public string status { get; set; }

//        [StringLength(255)]
//        public string house_number { get; set; }

//        [StringLength(255)]
//        public string street { get; set; }

//        [StringLength(255)]
//        public string city { get; set; }

//        [StringLength(255)]
//        public string country { get; set; }

//        [StringLength(255)]
//        public string state { get; set; }

//        [StringLength(255)]
//        public string zipCode { get; set; }

//        [StringLength(255)]
//        public string cin { get; set; }

//        [StringLength(255)]
//        public string first_name { get; set; }

//        [StringLength(255)]
//        public string last_name { get; set; }

//        public int? Age { get; set; }

//        [StringLength(255)]
//        public string Description { get; set; }

//        [StringLength(255)]
//        public string DriverLience { get; set; }

//        [Column(TypeName = "bit")]
//        public bool? ProfileValide { get; set; }

//        [StringLength(255)]
//        public string SocialState { get; set; }

//        [StringLength(255)]
//        public string picture { get; set; }

//        [StringLength(255)]
//        public string Birthdate { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<cv> cvs { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Message> messages { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<t_action> t_action { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<t_critere> t_critere { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<User_log> user_log { get; set; }
//    }
//}
