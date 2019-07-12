namespace Cobiax.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page
    {
        public int Id { get; set; }

        [Column("Page")]
        public string Page1 { get; set; }
    }
}
