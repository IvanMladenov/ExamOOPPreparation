namespace ConsoleForum.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    internal class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            List<string> passwords = users.Select(x => x.Password).ToList();
            var usernames = users.Select(x => x.Username).ToList();

            if (passwords.Contains(password) && usernames.Contains(username))
            {
                this.Forum.CurrentUser = users.FirstOrDefault(x => x.Username == username && x.Password == password);
                this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
            }
            else
            {
                this.Forum.Output.AppendLine(Messages.InvalidLoginDetails);
            }
        }
    }
}