namespace RestaurantManager.Models
{
    using System;
    using System.Text;

    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink
    {
        private const int MaxCalories=100;

        private const int MaxTimeToPrepare = 20;

        private int calories;

        private int timeToPrepare;

        public Drink(
            string name, 
            decimal price, 
            int calories, 
            int quantityPerServing, 
            int timeToPrepare, 
            bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Calories = calories;
            this.TimeToPrepare = timeToPrepare;
            this.IsCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }

        public new int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            private set
            {
                if (value >MaxTimeToPrepare)
                {
                    throw new IndexOutOfRangeException("Too many time to prepare");
                }
                this.timeToPrepare = value;
            }
        }

        public new int Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                if (value > MaxCalories)
                {
                    throw new IndexOutOfRangeException("Too much calories");
                }
                this.calories = value;
            }
        }

        public bool IsCarbonated { get; set; }

        public override string ToString()
        {
            var sb=new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("Carbonated: {0}", this.IsCarbonated ? "yes" : "no"));

            return sb.ToString();
        }
    }
}