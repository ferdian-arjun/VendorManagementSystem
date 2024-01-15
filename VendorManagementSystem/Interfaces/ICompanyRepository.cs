using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorManagementSystem.Models;

namespace VendorManagementSystem.Interfaces
{
    public interface ICompanyRepository : IGeneralRepository<Company, string>
    {
    }
}
