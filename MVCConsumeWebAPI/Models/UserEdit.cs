namespace MVCConsumeWebAPI.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;


   // public class User : IdentityUser   
    public class UserEdit
    {




        public int id { get; set; }

        [Required]
        [StringLength(31)]

        public string role { get; set; }


        [Required]
        [StringLength(255)]
        [EmailAddress]
        [Remote("doesEmailExistEdit", "User", ErrorMessage = "Ce nom d'utilisateur existe deja, veuillez choisir un autre.")]
        public string email { get; set; }

        [StringLength(255)]
        [Remote("doesLoginExistEdit", "User", ErrorMessage = "Ce nom d'utilisateur existe deja, veuillez choisir un autre.")]
        public string login { get; set; }

        [JsonIgnore]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "Le mot de passe de confirmation est different.")]
        public string confirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit avoir au moin {2} characters .", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        [JsonProperty(PropertyName = "registration_date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
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
        public string cin { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        public int? Age { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string DriverLience { get; set; }

        [Column(TypeName = "bit")]
        public bool? ProfileValide { get; set; }

        [StringLength(255)]
        public string SocialState { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string Birthdate { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public virtual ICollection<cv> cvs { get; set; }

        public virtual ICollection<Message> messages { get; set; }

        public virtual ICollection<t_action> t_action { get; set; }

        public virtual ICollection<t_critere> t_critere { get; set; }

        public virtual IEnumerable<User_log> user_log { get; set; }
    }
}
