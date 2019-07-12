namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Content
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [StringLength(50)]
        public int Subject { get; set; }

        [StringLength(100)]
        public string Text { get; set; }

        [StringLength(2000)]
        public string MoreText { get; set; }
    }
}
