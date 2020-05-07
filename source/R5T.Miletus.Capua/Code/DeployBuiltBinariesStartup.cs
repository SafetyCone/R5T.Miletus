using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Capua;
using R5T.Capua.Standard;
using R5T.Dacia;
using R5T.Karlstad;
using R5T.Lombardy;
using R5T.Macommania;
using R5T.Macommania.Standard;
using R5T.Miletus.Common;
using R5T.Richmond;
using R5T.Palembang;
using R5T.Palembang.Default;
using R5T.Ujung;


namespace R5T.Miletus.Capua
{
    public class DeployBuiltBinariesStartup : StartupBase
    {
        public DeployBuiltBinariesStartup(ILogger<StartupBase> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddDeployBuiltBinariesAction<IDeployBuiltBinariesAction>(
                    new ServiceAction<IBuildConfigurationNameProvider>(() => services.AddSingleton<IBuildConfigurationNameProvider, StaticValueBuildConfigurationNameProvider>()),
                    new ServiceAction<IProjectNameProvider>(() => services.AddSingleton<IProjectNameProvider, StaticValueProjectNameProvider>()),
                    new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddSingleton<ISolutionDirectoryPathProvider, SolutionDirectoryPathProvider>()),
                    new ServiceAction<ITargetFrameworkNameProvider>(() => services.AddSingleton<ITargetFrameworkNameProvider, StaticValueTargetFrameworkNameProvider>())
                )
                .AddExecutableFileDirectoryPathProvider<IExecutableFileDirectoryPathProvider>()
                .AddSingleton<ISolutionAndProjectFileSystemConvention, StandardSolutionAndProjectFileSystemConvention>()
                .AddDefaultStringlyTypedPathOperator<IStringlyTypedPathOperator>()
                ;
        }
    }
}
