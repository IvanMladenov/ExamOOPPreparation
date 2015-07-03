namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public abstract class Estate : IEstate
    {
        private const int MinArea = 0;

        private const int MaxArea = 1000;

        private double area;

        private string location;

        private string name;

        protected Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public EstateType Type { get; set; }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value < MinArea || value > MaxArea)
                {
                    throw new ArgumentOutOfRangeException("Area must be between [1...1000]");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Location cannot be null or empty");
                }

                this.location = value;
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string furnished = this.IsFurnished ? "Yes" : "No";
            sb.Append(
                string.Format(
                    "{4}: Name = {0}, Area = {1}, Location = {2}, Furnitured = {3}", 
                    this.Name, 
                    this.Area, 
                    this.Location, 
                    furnished, 
                    this.Type));
            return sb.ToString();
        }
    }
}