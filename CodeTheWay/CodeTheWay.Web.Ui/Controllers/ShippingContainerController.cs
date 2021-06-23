using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Services;

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
                if (model.Weight >= 0)
                {
                    ShippingContainer shippingContainer = new ShippingContainer()
                    {
                        Id = model.Id,
                        Destination = model.Destination,
                        Weight = model.Weight,
                    };
                    await ShippingContainerService.Create(shippingContainer);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentShippingContainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel shippingContainer = new ShippingContainerRegistrationViewModel()
            {
                Id = currentShippingContainer.Id,
                Destination = currentShippingContainer.Destination,
                Weight = currentShippingContainer.Weight,
            };
            return View(shippingContainer);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight >= 0)
                {
                    ShippingContainer shippingContainer = new ShippingContainer()
                    {
                        Id = model.Id,
                        Destination = model.Destination,
                        Weight = model.Weight,
                    };
                    await ShippingContainerService.Update(shippingContainer);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var currentShippingContainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel shippingContainer = new ShippingContainerRegistrationViewModel()
            {
                Id = currentShippingContainer.Id,
                Weight = currentShippingContainer.Weight,
                Destination = currentShippingContainer.Destination,
            };
            return View(shippingContainer);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var shippingContainer = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shippingContainer);

            return RedirectToAction("Index");
        }
    }
}
