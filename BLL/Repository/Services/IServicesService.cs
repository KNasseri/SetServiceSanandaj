using BOL.Domain;
using System.Collections;
using System.Collections.Generic;

namespace BLL.Repository.Services
{
    public partial interface IServicesService
    {
        Service GetServiceById(int id);

        IList<Service> GetAllServices();

        IList<Service> GetAllServices(int categoryId);

        void InsertService(Service service);
    }
}
