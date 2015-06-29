using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;

    public class LogoutCommand:AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);

            }
            this.Forum.CurrentUser = null;
            this.Forum.Output.AppendLine(Messages.LogoutSuccess);
            
            
            //this.Forum.CurrentQuestion = null;
        }
    }
}
