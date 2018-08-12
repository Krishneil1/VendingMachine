using Accentic.Business.Interfaces.Services;
using Accentis.Business.Service.VenderMachine.Business.Service;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accentis.Controllers
{
    public class VenderMachineController : BaseController
    {
        private readonly IVenderMachineService venderMachineService;

        public VenderMachineController()
        {
            venderMachineService = new VenderMachineService(UnitOfWork);
        }

        // GET: VenderMachine
        public ActionResult Admin()
        {
            var productData = venderMachineService.GetAll();
            return View("Index", productData.ToList());
        }
        public ActionResult AddEditProduct(VenderMachine venderMachine)
        {
            try
            {
                if (venderMachine.ProductId.ToString() != Guid.Empty.ToString())
                {
                    var product = venderMachineService.GetById(venderMachine.ProductId);
                    product.ProductName = venderMachine.ProductName;
                    product.Quantity = venderMachine.Quantity;
                    product.PerItemPrice = venderMachine.PerItemPrice;
                    venderMachineService.EditAddProduct(product);
                }
                else
                {
                    venderMachineService.EditAddProduct(venderMachine);
                }
                return Json(new { });
            }
            catch (Exception ex)
            {
                return Json(new { });
            }
        }

        public ActionResult GetProduct(Guid id)
        {
            try
            {
                var data = venderMachineService.GetById(id);
                return Json(new { Data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        public ActionResult User()
        {
            ViewData["Product"] = new SelectList(venderMachineService.GetAll().Where(x => x.Quantity != 0).ToList(), "ProductId", "ProductName");

            return View();
        }

        public ActionResult GetProductPrice(Guid id)
        {
            return Json(new { Data = venderMachineService.GetById(id) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductPurchase(Guid id, int quantity, double total)
        {
            var data = venderMachineService.GetById(id);
            data.Quantity = data.Quantity - quantity;
            data.SoldQuantity = quantity;
            data.Collection = data.Collection + total;
            venderMachineService.EditAddProduct(data);
            return RedirectToAction("Index", "ThankYou");

        }

        public ActionResult Reset()
        {
            try
            {
                var productData = venderMachineService.GetAll().ToList();
                foreach (var data in productData)
                {
                    data.Collection = 0;
                    data.Quantity = 0;
                    data.SoldQuantity = 0;
                    data.PerItemPrice = 0;
                    venderMachineService.EditAddProduct(data);
                }

                return Json(new { Data = "Done" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}