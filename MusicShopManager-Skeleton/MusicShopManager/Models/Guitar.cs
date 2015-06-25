using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public abstract class Guitar:Instrument,IGuitar
    {
        private const int DefaultNumberOfStrings = 6;

        private string bodyWood;

        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color,string bodyWood,string fingerboardWood)
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood
        {
            get
            {
                return this.bodyWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The body wood of a guitar is required.");
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this.fingerboardWood;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The fingerboard wood of a guitar is required.");
                }
                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings
        {
            get
            {
                return DefaultNumberOfStrings;
            }
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(base.ToString());
            sb.AppendFormat("Strings: {0}", this.NumberOfStrings.ToString()).AppendLine();
            sb.AppendFormat("Body wood: {0}", this.BodyWood).AppendLine();
            sb.AppendFormat("Fingerboard wood: {0}", this.FingerboardWood).AppendLine();

            return sb.ToString();
        }
    }
}
