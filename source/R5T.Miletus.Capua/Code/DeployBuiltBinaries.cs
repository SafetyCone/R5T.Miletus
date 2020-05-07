using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using R5T.Capua;
using R5T.Liverpool;


namespace R5T.Miletus.Capua
{
    public class DeployBuiltBinaries : AsyncHostedServiceProgramBase
    {
        public static async Task SubMain()
        {
            await HostedServiceProgram.RunAsync<DeployBuiltBinaries, DeployBuiltBinariesStartup>();
        }

        private IDeployBuiltBinariesAction DeployBuiltBinariesAction { get; }


        public DeployBuiltBinaries(IApplicationLifetime applicationLifetime,
            IDeployBuiltBinariesAction deployBuiltBinariesAction)
            : base(applicationLifetime)
        {
            this.DeployBuiltBinariesAction = deployBuiltBinariesAction;
        }

        protected override async Task SubMainAsync()
        {
            await this.DeployBuiltBinariesAction.RunAsync();
        }
    }
}
