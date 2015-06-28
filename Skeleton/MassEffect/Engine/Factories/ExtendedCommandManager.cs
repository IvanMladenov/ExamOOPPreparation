using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine.Factories
{
    using MassEffect.Engine.Commands;

    public class ExtendedCommandManager:CommandManager
    {
        public override void SeedCommands()
        {         
            this.commandsByName.Add("system-report", new SystemReportCommand(this.Engine));
            base.SeedCommands();
        }
    }
}
