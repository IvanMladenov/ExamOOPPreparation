namespace RestaurantManager.Models
{
    using System.Text;

    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        public Salad(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.ContainsPasta = containsPasta;
            this.IsVegan = true;
        }

        public bool ContainsPasta { get; private set; }

        public override string ToString()
        {
            var sb=new StringBuilder();
            sb.Append("[VEGAN] ");
            sb.Append(base.ToString()).AppendLine();
            sb.AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no").AppendLine();

            return sb.ToString();
        }
    }
}