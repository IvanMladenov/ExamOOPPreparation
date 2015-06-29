namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;

    public class Question :Post,IQuestion
    {
        public Question(int id,string body, IUser author, string title)
            : base(id,body,author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[ Question ID: {0} ]", this.Id).AppendLine();
            sb.AppendFormat("Posted by: {0}", this.Author).AppendLine();
            sb.AppendFormat("Question Title: {0}", this.Title).AppendLine();
            sb.AppendFormat("Question Body: {0}", this.Body).AppendLine();
            sb.AppendLine("====================");
            if (this.Answers.Count == 0)
            {
                sb.Append("No answers");
            }
            else
            {
                sb.AppendLine("Answers:");
                if (this.Answers.Any(x => x is BestAnswer))
                {
                    var bestAnswer = this.Answers.FirstOrDefault(x => x is BestAnswer) as BestAnswer;
                    sb.AppendLine(bestAnswer.ToString());
                    this.Answers.Remove(bestAnswer);
                    
                }

                var answersOrderd = this.Answers.OrderBy(x => x.Id);
                sb.Append(string.Join("\n", this.Answers));
            }

            return sb.ToString();
        }
    }
}