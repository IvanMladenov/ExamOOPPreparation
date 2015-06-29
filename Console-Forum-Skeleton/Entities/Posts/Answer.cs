using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class Answer:Post,IAnswer
    {
        public Answer(int id, string body,IUser author)
            : base(id,body, author)
        {
            this.Id = id;            
        }

        public override string ToString()
        {
            var sb =new StringBuilder();

            sb.AppendFormat("[ Answer ID: {0} ]", this.Id).AppendLine();
            sb.AppendFormat("Posted by: {0}", this.Author).AppendLine();
            sb.AppendFormat("Answer Body: {0}", this.Body).AppendLine();
            sb.Append("--------------------");
            return sb.ToString();
        }
    }
}
