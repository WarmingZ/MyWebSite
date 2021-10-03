using MyWebSite.Domain.Entities;
using System;
using System.Linq;

namespace MyWebSite.Domain.Repositories.Abstract
{
  public  interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
    }
}
