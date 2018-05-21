namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.vaitro")]
    public partial class vaitro
    {
        public int ID { get; set; }

        [StringLength(45)]
        public string Ten { get; set; }
    }
}
