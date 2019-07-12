namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SliderForService
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] img { get; set; }

        public int? Service_Id { get; set; }

        public virtual Service Service { get; set; }

        public virtual Service Service1 { get; set; }
    }
}
