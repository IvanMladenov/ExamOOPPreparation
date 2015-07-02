namespace RestaurantManager.Models
{
    using System.Text;

    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.WithSugar = true;
        }

        public bool WithSugar { get; set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var sb=new StringBuilder();
            sb.AppendFormat("{0}", this.WithSugar ? string.Empty : "[NO SUGAR] ");
            sb.AppendFormat("{0}", this.IsVegan ? "[VEGAN] " : string.Empty);
            sb.Append(base.ToString());

            return sb.ToString();
        }
    }
}