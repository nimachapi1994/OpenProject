namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MainSlider")]
    public partial class MainSlider
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
