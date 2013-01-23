using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yara.VoucherShop.Domain.ViewModels.VoucherModels
{
    public class VoucherCategoryViewModel
    {
        public long Id { get; set; }
        public Nullable<long> ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
