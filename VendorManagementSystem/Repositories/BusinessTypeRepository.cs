using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VendorManagementSystem.Interfaces;
using VendorManagementSystem.Models;

namespace VendorManagementSystem.Repositories
{
    public class BusinessTypeRepository : GeneralRepository<BusinessType, string>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(DbContext context) : base(context)
        {
        }
    }
}