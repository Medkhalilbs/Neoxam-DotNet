namespace MVCConsumeWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class cv
    {


        public int id { get; set; }

        [StringLength(255)]
        public string FilePath { get; set; }

        public float FileSize { get; set; }

        [StringLength(255)]
        public string FileType { get; set; }

        [StringLength(255)]
        public string OriginalFileType { get; set; }

        [StringLength(255)]
        public string SenderIp { get; set; }

        public int? Candidates_id { get; set; }

        public virtual ICollection<hoby> hobies { get; set; }

        public virtual ICollection<formation> formations { get; set; }

        public virtual ICollection<experience> experiences { get; set; }

        public virtual ICollection<project> projects { get; set; }

        public virtual ICollection<skill> skills { get; set; }

        public virtual ICollection<language> languages { get; set; }

        public virtual User user { get; set; }
    }
}
