using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Commands
{
    using System.Runtime.CompilerServices;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;
    using ConsoleForum.Entities.Users;

    public class MakeBestAnswerCommand:AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int answerId = int.Parse(this.Data[1]);
            var answer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(x => x.Id == answerId);

            if (this.Forum.CurrentUser == null)
            {
                this.Forum.Output.AppendLine(Messages.NotLogged);
            }
            else if (this.Forum.CurrentQuestion == null)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestionOpened);
            }
            else if (answer == null)
            {
                this.Forum.Output.AppendLine(Messages.NoAnswer);
            }
            else if (this.Forum.CurrentQuestion.Author != this.Forum.CurrentUser &&
                    this.Forum.CurrentUser.GetType() != typeof(Administrator))
            {
                this.Forum.Output.AppendLine(Messages.NoPermission);
            }
            else
            {
                BestAnswer bestAnswer = new BestAnswer(answerId,answer.Body,answer.Author);
                this.Forum.CurrentQuestion.Answers.Remove(answer);
                this.Forum.CurrentQuestion.Answers.Add(bestAnswer);
                this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, bestAnswer.Id));
            }
        }
    }
}
