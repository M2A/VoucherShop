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
    
    public partial class InvoiceDetail
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public long VoucherId { get; set; }
        public int Count { get; set; }
        public int Amount { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}