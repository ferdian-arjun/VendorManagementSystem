using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VendorManagementSystem.Interfaces;
using VendorManagementSystem.Models;

namespace VendorManagementSystem.Repositories
{
    public class ProjectRepository : GeneralRepository<Project, string>, IProjectRepository
    {
        public ProjectRepository(DbContext context) : base(context)
        {
        }
    }
}