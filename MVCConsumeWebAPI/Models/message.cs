namespace MVCConsumeWebAPI.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;


    public class Message
    {
 
        public int id { get; set; }

      
        public string contenu { get; set; }
        [JsonProperty(PropertyName = "dateEnvoie")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? dateEnvoie { get; set; }
    

        [JsonProperty(PropertyName = "dateLecture")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? dateLecture { get; set; }

        [Remote("doesLoginExist", "Message", ErrorMessage = "Veuillez choisir un nom d'utilisateur valide.")]
        [StringLength(255)]
        public string destinataire { get; set; }

        [StringLength(255)]
        public string statusMessage { get; set; }

        [StringLength(255)]
        public string sujet { get; set; }

        [StringLength(255)]
        public string visibiliteMessage { get; set; }

        [JsonIgnore]
        public int? user_id { get; set; }

        public virtual User user { get; set; }
    }
}
