using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ForInterview.Authorization;

namespace ForInterview
{
    [DependsOn(
        typeof(ForInterviewCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ForInterviewApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ForInterviewAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ForInterviewApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
