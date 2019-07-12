namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SliderForProject
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] img { get; set; }

        public int? Project_Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual Project Project1 { get; set; }

        public virtual Project Project2 { get; set; }
    }
}
