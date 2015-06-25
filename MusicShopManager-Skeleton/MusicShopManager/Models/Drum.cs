using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public class Drum:Instrument,IDrums
    {
        private int width;

        private int height;

        public Drum(string make, string model, decimal price, string color, int width,int height)
            : base(make, model, price, color)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The width of a set of drums must be positive.");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The height of a set of drums must be positive.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(base.ToString());
            sb.AppendFormat("Size: {0}cm x {1}cm", this.Width.ToString(), this.Height.ToString()).AppendLine();

            return sb.ToString();
        }
    }
}
