using System;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using VendorManagementSystem.Controllers;
using VendorManagementSystem.Interfaces;
using VendorManagementSystem.Models;
using VendorManagementSystem.Repositories;
using VendorManagementSystem.Services;

namespace VendorManagementSystem
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterComponents()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.

            container.RegisterType<DbContext, DB_VMSEntities>();

            //Repositories
            container.RegisterType(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IBusinessTypeRepository, BusinessTypeRepository>();
            container.RegisterType<ICategoryTypeRepository, CategoryTypeRepository>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<ICompanyProjectRepository, CompanyProjectRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();

            //Services
            container.RegisterType<RoleService>();


            //Controllers
            container.RegisterType<RoleController>();
        }
    }
}