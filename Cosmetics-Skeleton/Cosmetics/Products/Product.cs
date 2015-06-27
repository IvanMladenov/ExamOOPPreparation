namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private string brand;

        private string name;

        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

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
                    10, 
                    3, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    10, 
                    2, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                this.brand = value;
            }
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
                    throw new ArgumentException("Prise must be non negative.");
                }

                this.price = value;
            }
        }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("- {0} - {1}:", this.Brand, this.Name).AppendLine();
            sb.AppendFormat("  * Price: ${0}", this.Price).AppendLine();
            sb.AppendFormat("  * For gender: {0}", this.Gender).AppendLine();

            return sb.ToString();
        }
    }
}