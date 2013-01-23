using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yara.VoucherShop.Domain.ViewModels.VoucherModels;

namespace Yara.VoucherShop.Domain.ViewModels.CartModels
{
    public class CartDetailViewModel
    {
        public List<VouchersDetailBySubCatViewModel> VouchersDetail { set; get; }
        [Display(Name = "Sub Total")]
        public long TotalPrice { set; get; }
    }
}
