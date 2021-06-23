using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ShippingContainerService.GetShippingContainers());
        }
        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingContainer shippingcontainer = new ShippingContainer()
                {
                    Id = model.Id,
                    Weight = model.Weight,
                    Destination = model.Destination,

                };
                var student2 = await ShippingContainerService.Create(shippingcontainer);
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");

            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingContainer shippingcontainer = new ShippingContainer
                {
                    Id = model.Id,
                    Weight = model.Weight,
                    Destination = model.Destination,
                };
                ShippingContainer shippingcontainer2 = await ShippingContainerService.Update(shippingcontainer);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Edit(Guid id)
        {

            var student = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel ship = new ShippingContainerRegistrationViewModel()
            {
                Id = student.Id,
                Weight = student.Weight,
                Destination = student.Destination,
            };
            return View(ship);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var shipper = await ShippingContainerService.GetShippingContainer(id);
            return View(shipper);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var shipping = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shipping);
            return RedirectToAction("Index");
        }
    }

}