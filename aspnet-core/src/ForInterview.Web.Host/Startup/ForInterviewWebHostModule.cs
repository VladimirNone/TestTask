using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ForInterview.Configuration;

namespace ForInterview.Web.Host.Startup
{
    [DependsOn(
       typeof(ForInterviewWebCoreModule))]
    public class ForInterviewWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ForInterviewWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ForInterviewWebHostModule).GetAssembly());
        }
    }
}
