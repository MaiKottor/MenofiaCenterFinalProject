namespace MenofiaCenter.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class lab
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lab_id { get; set; }

        public int service_id { get; set; }

        [StringLength(50)]
        public string lab_name { get; set; }

        public int? floor_number { get; set; }

        public string description { get; set; }

        public virtual service service { get; set; }
    }
}
