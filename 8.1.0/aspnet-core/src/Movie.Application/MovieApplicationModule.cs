using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Movie.Authorization;

namespace Movie
{
    [DependsOn(
        typeof(MovieCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MovieApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MovieAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MovieApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
