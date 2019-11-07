namespace MVCConsumeWebAPI.Models
{

    using System.ComponentModel.DataAnnotations;


    public class t_action
    {
        public int idAction { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public double pourcentage { get; set; }

        public int? type { get; set; }

        public int? admin_id { get; set; }

        public virtual User user { get; set; }
    }
}
