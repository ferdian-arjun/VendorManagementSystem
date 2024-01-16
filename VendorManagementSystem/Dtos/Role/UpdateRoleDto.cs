using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendorManagementSystem.ViewModel;

namespace VendorManagementSystem.Dtos.Role
{
    public class UpdateRoleDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }

        public static explicit operator UpdateRoleDto(RoleViewModel role)
        {
            return new UpdateRoleDto()
            {
                Guid = role.Guid,
                Name = role.Name
            };
        }
    }
}