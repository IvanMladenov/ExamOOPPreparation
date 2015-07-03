namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer()
            : base(OfferType.Sale)
        {
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Price must be positive");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(", Price = {0}", this.Price));

            return sb.ToString();
        }
    }
}