using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yara.VoucherShop.Repository;
using Yara.VoucherShop.Domain;
using Yara.VoucherShop.Domain.ViewModels.VoucherModels;

namespace Yara.VoucherShop.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly Repository<SubCategory> _subCategoryRepository;
        public HomeController()
        {
            _subCategoryRepository = new Repository<SubCategory>(new VoucherShopEntities());
        }
        public ActionResult Index()
        {
            var subCategories = _subCategoryRepository.GetAll();
            VoucherSubCategoryListViewModel subCategoriesList = new VoucherSubCategoryListViewModel();
            subCategoriesList.SubCategories = new List<VoucherSubCategoryViewModel>();
            foreach (var subCategory in subCategories)
            {
                subCategoriesList.SubCategories.Add(new VoucherSubCategoryViewModel 
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    ImageURL = subCategory.ImageURL,
                    Description = subCategory.Description,
                    CategoryId = subCategory.CategoryId                    
                });
            }
            return View(subCategoriesList);
        }

    }
}
