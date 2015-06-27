namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.Products = new List<IProduct>();
        }

        public IList<IProduct> Products { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    15, 
                    2, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.Products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.Products.Contains(cosmetics))
            {
                Console.WriteLine("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name);
                return;
            }

            this.Products.Remove(cosmetics);
        }

        public string Print()
        {
            string product = string.Empty;
            if (this.Products.Count == 0)
            {
                return string.Format("{0} category - {1} {2} in total", this.Name, 0, "products");
            }

            product = this.Products.Count == 1 ? "product" : "products";

            var ordered = this.Products.OrderBy(x => x.Brand).ThenByDescending(p => p.Price).ToList();
            var sb = new StringBuilder();
            sb.AppendFormat("{0} category - {1} {2} in total", this.Name, this.Products.Count, product).AppendLine();
            for (int i = 0; i < ordered.Count; i++)
            {
                if (i != ordered.Count - 1)
                {
                    sb.AppendLine(ordered[i].Print());
                }
                else
                {
                    sb.Append(ordered[i].Print());
                }
            }

            return sb.ToString();
        }
    }
}