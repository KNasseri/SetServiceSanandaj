using BOL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Companies
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAllCompanies();

        Company GetCompanyById(int id);
    }
}
