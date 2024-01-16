using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VendorManagementSystem.Dtos.Role;
using VendorManagementSystem.Services;
using VendorManagementSystem.ViewModel;

namespace VendorManagementSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        protected override void Dispose(bool disposing)
        {
            _roleService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read_Role([DataSourceRequest]DataSourceRequest request)
        {
            var roles = _roleService.GetAll(); 
            var roleVMs = roles.Select(role => new RoleViewModel()
            {
                Guid = role.Guid,
                Name = role.Name
            });

            return Json(roleVMs.ToDataSourceResult(request));
        }

        public ActionResult Create_Role([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            _roleService.Create((CreateRoleDto)roleViewModel);

            return Json(new[] { roleViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update_Role([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (roleViewModel == null && !ModelState.IsValid) return Json(ModelState.ToDataSourceResult());

            _roleService.Update((UpdateRoleDto)roleViewModel);

            return Json(true);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete_Role([DataSourceRequest] DataSourceRequest request, RoleViewModel roleViewModel)
        {
            if (roleViewModel.Guid == null && !ModelState.IsValid) return Json(ModelState.ToDataSourceResult());

            _roleService.Delete(roleViewModel.Guid);

            return Json(true);
        }

        
    }
}