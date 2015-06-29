namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questionsOrdered = this.Forum.Questions.OrderBy(x => x.Id).ToList();
            if (questionsOrdered.Count == 0)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {

                this.Forum.Output.AppendLine(String.Join("\n", questionsOrdered));
                //foreach (var question in questionsOrdered)
                //{
                //    this.Forum.Output.AppendLine(question.ToString());
                //    //if (this.Forum.Answers.Count == 0)
                //    //{
                //    //    this.Forum.Output.AppendLine("No answers");
                //    //}
                //    //else
                //    //{
                //    //    if (this.Forum.Answers.Any(x => x is BestAnswer))
                //    //    {
                //    //        var bestAnswer = this.Forum.Answers.FirstOrDefault(x => x is BestAnswer) as BestAnswer;
                //    //        this.Forum.Output.AppendLine(bestAnswer.ToString());
                //    //        this.Forum.Answers.Remove(bestAnswer);
                //    //    }

                //    //    var answersOrderd = this.Forum.Answers.OrderBy(x => x.Id);
                //    //    foreach (var answer in answersOrderd)
                //    //    {
                //    //        this.Forum.Output.AppendLine(answer.ToString());
                //    //    }
                //    //}
                //}
            }
        }
    }
}