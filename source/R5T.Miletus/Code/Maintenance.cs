using System;
using System.Threading.Tasks;

using R5T.Miletus.Configuration;


namespace R5T.Miletus
{
    public static class Maintenance
    {
        public static async Task DeployBuiltBinaries(string projectName, string buildConfigurationName, string targetFrameworkName)
        {
            Configure.ProjectSpecificValues(projectName, buildConfigurationName, targetFrameworkName);

            // Scripts.
            await Capua.DeployBuiltBinaries.SubMain();
        }
    }
}
