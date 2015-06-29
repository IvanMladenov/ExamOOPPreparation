namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string body = this.Data[1];

            if (this.Forum.CurrentUser == null)
            {
                this.Forum.Output.AppendLine(Messages.NotLogged);
            }
            else if (this.Forum.CurrentQuestion == null)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestionOpened);
            }
            else
            {
                int id = this.Forum.Answers.Count + 1;
                this.Forum.Answers.Add(new Answer(id, body, this.Forum.CurrentUser));
                this.Forum.CurrentQuestion.Answers.Add(new Answer(id, body, this.Forum.CurrentUser));
                this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, id));
            }
        }
    }
}