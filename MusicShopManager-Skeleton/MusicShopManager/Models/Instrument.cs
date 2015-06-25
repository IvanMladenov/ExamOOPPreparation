using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public abstract class Instrument:Article,IInstrument
    {
        private string color;

        protected Instrument(string make, string model,decimal price, string color)
            : base(make, model,price)
        {
            this.Color = color;
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The color cant be null or empty");
                }
                this.color = value;
            }
        }

        public virtual bool IsElectronic { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendFormat("Color: {0}", this.Color).AppendLine();
            sb.AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no").AppendLine();
            return sb.ToString();
        }
    }
}
