namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string title = this.Data[1];
            string body = this.Data[2];

            if (this.Forum.CurrentUser == null)
            {
                this.Forum.Output.AppendLine(Messages.NotLogged);
            }
            else
            {
                this.Forum.Output.AppendLine(
                    string.Format(Messages.PostQuestionSuccess, this.Forum.Questions.Count + 1));
                this.Forum.Questions.Add(
                    new Question(this.Forum.Questions.Count + 1, body, this.Forum.CurrentUser, title));
            }
        }
    }
}