using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models;

namespace CodeTheWay.Web.Ui.Services
{
    public interface IShippingContainerService
    {
        public Task<ShippingContainer> Create(ShippingContainer shippingcontainer);
        public Task<List<ShippingContainer>> GetShippingContainers();
        public Task<ShippingContainer> GetShippingContainer(Guid id);
        public Task<ShippingContainer> Update(ShippingContainer shippingcontainer);
        public Task<ShippingContainer> Delete(ShippingContainer shippingcontainer);
    }
}
