using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ForInterview.EntityFrameworkCore;
using ForInterview.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ForInterview.Web.Tests
{
    [DependsOn(
        typeof(ForInterviewWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ForInterviewWebTestModule : AbpModule
    {
        public ForInterviewWebTestModule(ForInterviewEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ForInterviewWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ForInterviewWebMvcModule).Assembly);
        }
    }
}