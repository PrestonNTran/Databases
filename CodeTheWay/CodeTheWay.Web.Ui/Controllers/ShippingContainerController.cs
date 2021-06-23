using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight > 0)
                {
                    ShippingContainer shipCon = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
                    var newShippingContainer = await ShippingContainerService.Create(shipCon);
                }
                    return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var shipCon = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegisterViewModel stu = new ShippingContainerRegisterViewModel()
            {
                Id = shipCon.Id,
                Weight = shipCon.Weight,
                Destination = shipCon.Destination,
            };
            return View(shipCon);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(ShippingContainerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight > 0)
                {
                    ShippingContainer shipCon = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination,
                    };
                    var student = await ShippingContainerService.Update(shipCon);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegisterViewModel newShipCon = new ShippingContainerRegisterViewModel()
            {
                Id = student.Id,
                Weight = student.Weight,
                Destination = student.Destination,
            };

            return View(newShipCon);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var shipCon = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shipCon);
            return RedirectToAction("Index");
        }
    }
}