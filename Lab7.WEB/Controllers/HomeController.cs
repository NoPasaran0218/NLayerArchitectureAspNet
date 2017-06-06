using Lab7.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7.WEB.Controllers
{
    public class HomeController : Controller
    {
        IShopService shopService;
        public HomeController(IShopService serv)
        {
            shopService = serv;
        }
        public ActionResult Index()
        {
            return View(shopService.GetMenuItems());
        }

        public JsonResult CreateOrder(string[] arrIds, string price)
        {
            int[] Ids = new int[arrIds.Count()];
            for(int i=0;i<arrIds.Count();i++)
            {
                Int32.TryParse(arrIds[i], out Ids[i]);
            }
            int Price;
            Int32.TryParse(price, out Price);

            shopService.MakeOrder(Ids, Price);

            var result = new
            {
                status = "successful done"
            };
            return Json(result);
        }

        public ActionResult OrderList()
        {
            return View(shopService.GetAllOrder());
        }

        public JsonResult CompliteOrder(string id)
        {
            int Id;
            Int32.TryParse(id, out Id);

            try
            {
                shopService.CompliteOrder(Id);
            }
            catch(NullReferenceException ex)
            {
                return Json(new { Message=ex.Message });
            }
            var result = new
            {

            };
            return Json(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            shopService.Dispose();
            base.Dispose(disposing);
        }
    }
}