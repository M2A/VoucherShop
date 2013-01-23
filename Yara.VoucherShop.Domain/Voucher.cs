//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yara.VoucherShop.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voucher
    {
        public Voucher()
        {
            this.Carts = new HashSet<Cart>();
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
            this.VoucherDetails = new HashSet<VoucherDetail>();
        }
    
        public long Id { get; set; }
        public long SubCategoryId { get; set; }
        public string Pin { get; set; }
        public int Price { get; set; }
        public System.DateTime CreationDate { get; set; }
        public bool Freezed { get; set; }
        public bool Sold { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
    }
}