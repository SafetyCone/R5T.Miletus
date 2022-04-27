using System;

using R5T.Karlstad;
using R5T.Lombardy;using R5T.T0064;


namespace R5T.Miletus.Common
{[ServiceImplementationMarker]
    // Standard is based on ..\R5T.Capua.Console\source\ΩMaintenance\bin\Debug\netcoreapp2.2
    public class StandardSolutionAndProjectFileSystemConvention : ISolutionAndProjectFileSystemConvention,IServiceImplementation
    {
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public StandardSolutionAndProjectFileSystemConvention(
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public string GetSolutionDirectoryPathFromExecutableFileDirectoryPath(string executableFileDirectoryPath)
        {
            var ensuredExecutableFileDirectoryPath = this.StringlyTypedPathOperator.EnsureDirectoryPathIsDirectoryIndicated(executableFileDirectoryPath);

            var buildConfigurationDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(ensuredExecutableFileDirectoryPath); // Debug
            var binariesOutputDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(buildConfigurationDirectoryPath); // bin
            var projectDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(binariesOutputDirectoryPath); // ΩMaintenance
            var solutionDirectoryPath = this.StringlyTypedPathOperator.GetParentDirectoryPathForDirectoryPath(projectDirectoryPath); // source
            return solutionDirectoryPath;
        }
    }
}
