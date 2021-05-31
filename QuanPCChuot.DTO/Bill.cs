namespace QuanPCChuot.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        public long ID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public long StaffID { get; set; }

        [Required]
        public string ServiceIDs { get; set; }

        public decimal CostMoney { get; set; }

        public decimal SellMoney { get; set; }

        public bool Purchased { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
