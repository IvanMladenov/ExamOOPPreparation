using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using System.Runtime.CompilerServices;

    using MusicShopManager.Interfaces;

    public class Microphone:Article,IMicrophone
    {
        public Microphone(string make, string model,decimal price,bool hasCable)
            : base(make, model,price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; private set; }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(base.ToString());
            sb.AppendFormat("Cable: {0}", this.HasCable ? "yes" : "no").AppendLine();

            return sb.ToString();
        }
    }

}
