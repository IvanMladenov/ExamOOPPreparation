namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer()
            : base(OfferType.Rent)
        {
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Price must be positive");
                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(", Price = {0}", this.PricePerMonth));

            return sb.ToString();
        }
    }
}