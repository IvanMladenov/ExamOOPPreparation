using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public class BassGuitar:Guitar,IBassGuitar
    {
        private const int DefaultBassGuitarStrings = 4;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
        }

        public override int NumberOfStrings
        {
            get
            {
                return DefaultBassGuitarStrings;
            }
        }

        public override bool IsElectronic
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
