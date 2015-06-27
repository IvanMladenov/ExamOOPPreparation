namespace Cosmetics.Products
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.Products = new List<IProduct>();
        }

        public IList<IProduct> Products { get; set; }

        public void AddProduct(IProduct product)
        {
            this.Products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.Products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (this.Products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            if (this.Products.Count == 0)
            {
                return totalPrice;
            }

            foreach (var item in this.Products)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }
    }
}