using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yara.VoucherShop.Domain.ViewModels.VoucherModels
{
    public class VoucherSubCategoryListViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

        public List<VoucherSubCategoryViewModel> SubCategories { set; get; }
    }
}
