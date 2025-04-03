using Mar3HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mar3HW.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult Orders()
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            NorthwindViewModel vm = new NorthwindViewModel();
            vm.Orders = mgr.GetOrders();
            vm.CurrentDate = DateTime.Now;
            return View(vm);
        }




        public ActionResult OrderDetails()
        {
            NorthwindManager mgr = new NorthwindManager(Properties.Settings.Default.ConStr);
            NorthwindViewModel vm = new NorthwindViewModel();
            vm.OrderDetails = mgr.GetOrderDetails1997();
            return View(vm);
        }
    }
}