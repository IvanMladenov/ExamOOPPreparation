namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Toothpaste : Product, IToothpaste
    {
        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredient = ingredients;
        }

        public IList<string> Ingredient { get; set; }

        public string Ingredients { get; private set; }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());
            sb.AppendFormat("  * Ingredients: {0}", string.Join(", ", this.Ingredient));
            return sb.ToString();
        }
    }
}