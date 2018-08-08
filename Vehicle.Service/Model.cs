namespace Vehicle.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(20)]
        public string ModelName { get; set; }

        [StringLength(20)]
        public string abrv { get; set; }

        public int? MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
