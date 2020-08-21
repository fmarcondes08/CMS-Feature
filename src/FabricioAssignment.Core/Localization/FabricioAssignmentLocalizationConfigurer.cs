using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FabricioAssignment.Localization
{
    public static class FabricioAssignmentLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FabricioAssignmentConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FabricioAssignmentLocalizationConfigurer).GetAssembly(),
                        "FabricioAssignment.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
