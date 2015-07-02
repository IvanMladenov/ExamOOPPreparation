namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        public Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Unit = MetricUnit.Grams;
        }

        public bool IsVegan { get; set; }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}