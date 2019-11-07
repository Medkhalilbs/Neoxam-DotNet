namespace MVCConsumeWebAPI.Models
{

    using System.ComponentModel.DataAnnotations;
 


    public class t_critere
    {
      
        public int idCritere { get; set; }

        [StringLength(255)]
        public string DescrCritere { get; set; }

        public int Pourcentage { get; set; }

        public int? admin_id { get; set; }

        public virtual User user { get; set; }
    }
}
