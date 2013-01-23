using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yara.VoucherShop.Domain;
using Yara.VoucherShop.Domain.ViewModels.CartModels;
using Yara.VoucherShop.Domain.ViewModels.VoucherModels;
using Yara.VoucherShop.Repository;

namespace Yara.VoucherShop.Web.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        private readonly Repository<Cart> _cartRepository;
        private readonly Repository<Voucher> _voucherRepository;
        private string CartGUID { set; get; }
        public CartController()
        {
            _cartRepository = new Repository<Cart>(new VoucherShopEntities());
            _voucherRepository = new Repository<Voucher>(new VoucherShopEntities());

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(long id)
        {

            if (Session["CartGUID"] == null)
            {
                CartGUID = Guid.NewGuid().ToString();
                Session["CartGUID"] = CartGUID;
            }
            else
            {
                CartGUID = Session["CartGUID"].ToString();
            }
            Voucher reservedVoucher = _voucherRepository.GetAll(p => p.Freezed == false && p.Sold == false && p.SubCategoryId == id).FirstOrDefault();
            if (reservedVoucher != null)
            {

                reservedVoucher.Freezed = true;
                _voucherRepository.Save();
                try
                {
                    _cartRepository.Add(new Cart()
                    {
                        GUID = CartGUID,
                        VoucherId = reservedVoucher.Id,
                        AddedTime = DateTime.Now,
                        SubCategoryId = reservedVoucher.SubCategoryId

                    });
                    _cartRepository.Save();
                }
                catch (Exception)
                {
                    _voucherRepository.Get(p => p.Id == reservedVoucher.Id).Freezed = false;
                    _voucherRepository.Save();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetCount()
        {
            if (Session["CartGUID"] == null)
                ViewData["cartCount"] = 0;
            else
            {
                string sessionGUID = Session["CartGUID"].ToString();
                int count = _cartRepository.GetAll(p => p.GUID == sessionGUID).Count();
                ViewData["cartCount"] = count;
            }
            return PartialView("GetCount");
        }

        public ActionResult Detail()
        {
            CartDetailViewModel cartDetail = new CartDetailViewModel();
            if (Session["CartGUID"] != null)
            {
                string sessionGUID = Session["CartGUID"].ToString();
                IEnumerable<Cart> cartItems = _cartRepository.GetAll(p => p.GUID == sessionGUID);
                if (cartItems != null)
                {
                    IEnumerable<IGrouping<long, Cart>> groupedCartItems = cartItems.GroupBy(p => p.SubCategoryId);
                    cartDetail.VouchersDetail = new List<VouchersDetailBySubCatViewModel>();
                    foreach (IGrouping<long, Cart> item in groupedCartItems)
                    {
                        cartDetail.VouchersDetail.Add(new VouchersDetailBySubCatViewModel
                        {
                            Quantity = item.Count(),
                            Description = item.FirstOrDefault().Voucher.SubCategory.Description,
                            Id = item.Key,
                            Image = item.FirstOrDefault().Voucher.SubCategory.ImageURL,
                            Name = item.FirstOrDefault().Voucher.SubCategory.Name,
                            UnitPrice = item.FirstOrDefault().Voucher.Price,
                        });
                    }
                }
                cartDetail.TotalPrice = cartDetail.VouchersDetail.Sum(p => p.TotalPrice);
                return View(cartDetail);
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
