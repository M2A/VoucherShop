using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yara.VoucherShop.Domain.ViewModels.VoucherModels
{
    public class VoucherDetailViewModel
    {
        public long Id { set; get; }
        public long SubCategoryId { set; get; }
        [Display(Name = "Name")]
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        [Display(Name = "Price")]
        public int Price { set; get; }

    }
}
