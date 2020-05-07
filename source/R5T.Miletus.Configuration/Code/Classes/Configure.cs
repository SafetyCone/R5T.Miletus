using System;

using R5T.Palembang.Default;


namespace R5T.Miletus.Configuration
{
    public static class Configure
    {
        public static void ConfigureProjectSpecificValues(string projectName, string buildConfigurationName, string targetFrameworkName)
        {
            StaticValueProjectNameProvider.ProjectName = projectName;
            StaticValueBuildConfigurationNameProvider.BuildConfigurationName = buildConfigurationName;
            StaticValueTargetFrameworkNameProvider.TargetFrameworkName = targetFrameworkName;
        }
    }
}
