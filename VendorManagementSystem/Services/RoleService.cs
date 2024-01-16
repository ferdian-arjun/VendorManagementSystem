using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using VendorManagementSystem.Dtos.Role;
using VendorManagementSystem.Interfaces;

namespace VendorManagementSystem.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<GetRoleDto> GetAll()
        {
            var roles = _roleRepository.GetAll();
            if (!roles.Any()) return null;

            var roleDtos = new List<GetRoleDto>();
            foreach (var role in roles)
            {
                roleDtos.Add((GetRoleDto)role);
            }
            
            return roleDtos;
        }

        public GetRoleDto Get(string guid)
        {
            var role = _roleRepository.Get(guid);
            if (role == null) return null;
            return (GetRoleDto)role;
        }

        public int Create(CreateRoleDto createRoleDto)
        {
            return _roleRepository.Post(createRoleDto);
        }

        public int Update(UpdateRoleDto updateRoleDto)
        {
            var entity = _roleRepository.Get(updateRoleDto.Guid);
            if (entity == null) return -1;

            entity.name = updateRoleDto.Name;

            return _roleRepository.Put(entity);
        }

        public int Delete(string guid)
        {
            var entity = _roleRepository.Get(guid);
            if (entity == null) return -1;

            return _roleRepository.SoftDelete(entity);
        }

        public void Dispose()
        {
            _roleRepository.Dispose();
        }
    }
}