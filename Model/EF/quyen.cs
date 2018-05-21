namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.quyen")]
    public partial class quyen
    {
        public int ID { get; set; }

        [StringLength(45)]
        public string Ten { get; set; }
    }
}
