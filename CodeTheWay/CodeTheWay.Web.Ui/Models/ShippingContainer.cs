using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Models
{
    public class ShippingContainer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
