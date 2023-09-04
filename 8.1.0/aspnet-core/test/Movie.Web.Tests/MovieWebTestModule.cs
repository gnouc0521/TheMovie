using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Movie.EntityFrameworkCore;
using Movie.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Movie.Web.Tests
{
    [DependsOn(
        typeof(MovieWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MovieWebTestModule : AbpModule
    {
        public MovieWebTestModule(MovieEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MovieWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MovieWebMvcModule).Assembly);
        }
    }
}