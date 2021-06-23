using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Repositories
{
    public interface IShippingContainerRepository
    {
        public Task<ShippingContainer> Create(ShippingContainer shippingContainer);
        public Task<List<ShippingContainer>> GetShippingContainers();
        public Task<ShippingContainer> GetShippingContainer(Guid id);
        public Task<ShippingContainer> Update(ShippingContainer model);
        public Task<ShippingContainer> Delete(ShippingContainer model);
    }
}
