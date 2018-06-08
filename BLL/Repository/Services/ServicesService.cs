using BOL.Data;
using BOL.Domain;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BLL.Repository.Services
{
    public partial class ServicesService : IServicesService
    {
        private readonly IRepository<Service> _serviceRepo;

        public ServicesService()
        {
            _serviceRepo = new EfRepository<Service>();
        }

       
        public Service GetServiceById(int id)
        {
            return _serviceRepo.GetById(id);
        }


        public IList<Service> GetAllServices()
        {
            return _serviceRepo.Table.ToList();
        }


        public IList<Service> GetAllServices(int categoryId)
        {
            if (categoryId == 0)
                return new List<Service>();

            var query = from s in _serviceRepo.Table
                        where s.CategoryId == categoryId
                        select s;

            return query.ToList();
        }

        public void InsertService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            _serviceRepo.Insert(service);
        }
    }
}
