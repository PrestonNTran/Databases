using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CodeTheWay.Web.Ui.Services
{
    public class ShippingContainerService : IShippingContainerService
    {
        private IShippingContainerRepository ShippingRepo;

        public ShippingContainerService(AppDbContext dbContext)
        {
            this.ShippingRepo = new ShippingContainerRepository(dbContext);
        }

        public async Task<ShippingContainer> Create(ShippingContainer shipingcontainer)
        {
            return await this.ShippingRepo.Create(shipingcontainer);
        }

        public async Task<ShippingContainer> Delete(ShippingContainer shipingcontainer)
        {
            return await ShippingRepo.Delete(shipingcontainer);
        }

        public async Task<ShippingContainer> GetShippingContainer(Guid id)
        {
            return await this.ShippingRepo.GetShippingContainer(id);
        }
        public async Task<List<ShippingContainer>> GetShippingContainers()
        {
            return await this.ShippingRepo.GetShippingContainers();
        }

        public async Task<ShippingContainer> Update(ShippingContainer shipingcontainer)
        {
            return await ShippingRepo.Update(shipingcontainer);
        }    
    }
}
