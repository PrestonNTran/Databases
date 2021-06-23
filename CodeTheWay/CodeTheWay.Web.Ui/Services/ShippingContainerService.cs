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
        IShippingContainerRepository ShippingContainerRepository;

        public ShippingContainerService(AppDbContext dbContext)
        {
            this.ShippingContainerRepository = new ShippingContainerRepository(dbContext);
        }
        public async Task<ShippingContainer> Create(ShippingContainer shipCon)
        {
            return await this.ShippingContainerRepository.Create(shipCon);
        }
        public async Task<List<ShippingContainer>> GetShippingContainer()
        {
            return await this.ShippingContainerRepository.GetShippingContainer();
        }
        public async Task<ShippingContainer> GetShippingContainer(Guid id)
        {
            return await this.ShippingContainerRepository.GetShippingContainer(id);
        }
        public async Task<ShippingContainer> Update(ShippingContainer shipCon)
        {
            return await ShippingContainerRepository.Update(shipCon);
        }
        public async Task<ShippingContainer> Delete(ShippingContainer shipCon)
        {
            return await ShippingContainerRepository.Delete(shipCon);
        }
    }
}