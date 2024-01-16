using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendorManagementSystem.ViewModel;

namespace VendorManagementSystem.Dtos.Role
{
    public class CreateRoleDto
    {
        public string Name { get; set; }

        public static implicit operator Models.Role(CreateRoleDto roleDto)
        {
            return new Models.Role
            {
                guid = Guid.NewGuid().ToString(),
                name = roleDto.Name,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
        }

        public static explicit operator CreateRoleDto(RoleViewModel roleViewModel)
        {
            return new CreateRoleDto()
            {
                Name = roleViewModel.Name
            };
        }
    }
}