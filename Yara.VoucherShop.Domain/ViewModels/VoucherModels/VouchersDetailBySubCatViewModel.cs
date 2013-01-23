using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yara.VoucherShop.Domain.ViewModels.VoucherModels
{
    public class VouchersDetailBySubCatViewModel
    {
        public long Id { set; get; }
        [Display(Name = "Name")]
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        [Display(Name = "Unit Price")]
        public int UnitPrice { set; get; }
        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
        [Display(Name = "Total Price")]
        public int TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
