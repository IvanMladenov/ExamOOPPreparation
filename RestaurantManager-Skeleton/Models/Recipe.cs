namespace RestaurantManager.Models
{
    using System;
    using System.Globalization;
    using System.Text;

    using RestaurantManager.Interfaces;

    public abstract class Recipe : IRecipe
    {
        private string name;

        private decimal price;

        private int calories;

        private int quantityPerServing;

        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("The {0} must be positive.","price"));
                }
                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("The {0} must be positive.", "calories"));
                }
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }
            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("The {0} must be positive.", "quantity per serving"));
                }
                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit { get; set; }

        public int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("The {0} must be positive.", "time to prepare"));
                }
                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var sb=new StringBuilder();
            sb.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine();
            sb.AppendFormat(
                "Per serving: {0} {1}, {2} kcal",
                this.QuantityPerServing,
                this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories).AppendLine();
            sb.AppendFormat("Ready in {0} minutes", this.TimeToPrepare);

            return sb.ToString();
        }
    }
}