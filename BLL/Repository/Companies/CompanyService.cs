using BOL.Data;
using BOL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyService;

        public CompanyService()
        {
            _companyService = new EfRepository<Company>();
        }

        public IQueryable<Company> GetAllCompanies()
        {
            var query = _companyService.Table;

            return query;
        }

        public Company GetCompanyById(int id)
        {
            return _companyService.GetById(id);
        }
    }
}
