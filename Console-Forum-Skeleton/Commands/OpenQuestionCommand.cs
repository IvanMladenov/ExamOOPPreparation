namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);
            var question = this.Forum.Questions.FirstOrDefault(x => x.Id == questionId) as Question;
            if (question == null)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestion);
            }
            else
            {
                this.Forum.CurrentQuestion = question;
                this.Forum.Output.AppendLine(question.ToString());
            }
        }
    }
}