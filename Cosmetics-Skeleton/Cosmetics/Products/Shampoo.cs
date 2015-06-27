namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = price * milliliters;
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var sb = new StringBuilder(base.Print());
            sb.AppendFormat("  * Quantity: {0} ml", this.Milliliters).AppendLine();
            sb.AppendFormat("  * Usage: {0}", this.Usage);

            return sb.ToString();
        }
    }
}