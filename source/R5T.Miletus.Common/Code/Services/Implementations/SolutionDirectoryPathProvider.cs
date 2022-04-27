using System;

using R5T.Karlstad;
using R5T.Macommania;
using R5T.Ujung;using R5T.T0064;


namespace R5T.Miletus.Common
{[ServiceImplementationMarker]
    public class SolutionDirectoryPathProvider : ISolutionDirectoryPathProvider,IServiceImplementation
    {
        private IExecutableFileDirectoryPathProvider ExecutableFileDirectoryPathProvider { get; }
        private ISolutionAndProjectFileSystemConvention SolutionAndProjectFileSystemConventions { get; }


        public SolutionDirectoryPathProvider(
            IExecutableFileDirectoryPathProvider executableFileDirectoryPathProvider,
            ISolutionAndProjectFileSystemConvention solutionAndProjectFileSystemConventions)
        {
            this.ExecutableFileDirectoryPathProvider = executableFileDirectoryPathProvider;
            this.SolutionAndProjectFileSystemConventions = solutionAndProjectFileSystemConventions;
        }

        public string GetSolutionDirectoryPath()
        {
            var executableFileDirectoryPath = this.ExecutableFileDirectoryPathProvider.GetExecutableFileDirectoryPath();

            var solutionDirectoryPath = this.SolutionAndProjectFileSystemConventions.GetSolutionDirectoryPathFromExecutableFileDirectoryPath(executableFileDirectoryPath);
            return solutionDirectoryPath;
        }
    }
}
