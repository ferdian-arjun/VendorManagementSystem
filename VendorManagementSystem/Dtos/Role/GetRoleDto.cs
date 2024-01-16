using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendorManagementSystem.Dtos.Role
{
    public class GetRoleDto
    {
        public string Guid { get; set; }
        public string Name { get; set; }

        public static explicit operator GetRoleDto(Models.Role role)
        {
            return new GetRoleDto
            {
                Guid = role.guid, 
                Name = role.name
            };
        }
    }
}