namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public abstract class Offer : IOffer
    {
        protected IEstate estate;

        protected Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type { get; set; }

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.estate = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                string.Format("{0}: Estate = {1}, Location = {2}", this.Type, this.Estate.Name, this.Estate.Location));
            return sb.ToString();
        }
    }
}