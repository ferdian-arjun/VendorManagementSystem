using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VendorManagementSystem.Interfaces;
using VendorManagementSystem.Models;

namespace VendorManagementSystem.Repositories
{
    public class RoleRepository : GeneralRepository<Role, string>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}