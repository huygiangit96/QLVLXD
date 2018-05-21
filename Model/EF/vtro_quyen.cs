namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("qlvlxd.vtro_quyen")]
    public partial class vtro_quyen
    {
        public int ID { get; set; }

        public int? ID_VT { get; set; }

        public int? ID_Quyen { get; set; }
    }
}
