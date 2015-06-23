using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesShop
{
    public class Band:Performer,IBand
    {
        public Band(string name)
            : base(name)
        {
            this.Members=new List<string>();
        }

        public override PerformerType Type
        {
            get
            {
                 return PerformerType.Band;
            }
        }

        public IList<string> Members { get; private set; }

        public void AddMember(string memberName)
        {
            this.Members.Add(memberName);
        }
    }
}
