using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ForInterview.Localization
{
    public static class ForInterviewLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ForInterviewConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ForInterviewLocalizationConfigurer).GetAssembly(),
                        "ForInterview.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
