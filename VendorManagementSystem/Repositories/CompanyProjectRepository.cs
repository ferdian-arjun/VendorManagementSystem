using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VendorManagementSystem.Interfaces;
using VendorManagementSystem.Models;

namespace VendorManagementSystem.Repositories
{
    public class CompanyProjectRepository : GeneralRepository<CompanyProject, string>, ICompanyProjectRepository
    {
        public CompanyProjectRepository(DbContext context) : base(context)
        {
        }
    }
}