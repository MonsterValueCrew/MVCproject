using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MonsterValueCrew.Controllers;
using MonsterValueCrew.Data;
using MonsterValueCrew.DataServices;
using MonsterValueCrew.DataServices.Interfaces;
using MonsterValueCrew.Services;

using MonsterValueCrew.Services.Contracts;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MonsterValueCrew.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MonsterValueCrew.App_Start.NinjectWebCommon), "Stop")]

namespace MonsterValueCrew.App_Start
{

    [ExcludeFromCodeCoverage]
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ApplicationUserManager>()
                .ToMethod(_ => HttpContext
                .Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>());

            kernel.Bind<ApplicationDbContext>()
                .ToMethod(_ => HttpContext
                .Current.GetOwinContext()
                .GetUserManager<ApplicationDbContext>())
                .InRequestScope();

            kernel.Bind<IAdminService>().To<AdminService>();

            //kernel.Bind<ICourseService>().To<CourseService>();

            kernel.Bind<ICourseCrudService>().To<CourseCrudService>().InRequestScope();
           
        }        
    }
}
