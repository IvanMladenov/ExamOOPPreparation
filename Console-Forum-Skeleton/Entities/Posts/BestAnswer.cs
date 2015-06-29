using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;

    public class BestAnswer:Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder("********************").AppendLine();
            sb.AppendLine(base.ToString());
            sb.Append("********************");

            return sb.ToString();

        }
    }
}
