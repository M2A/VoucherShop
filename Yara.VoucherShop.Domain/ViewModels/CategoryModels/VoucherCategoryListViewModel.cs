using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yara.VoucherShop.Domain.ViewModels.VoucherModels
{
    public class VoucherCategoryListViewModel
    {
        public long Id { get; set; }
        public Nullable<long> ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public List<VoucherCategoryViewModel> Categories { set; get; }
    }
}
