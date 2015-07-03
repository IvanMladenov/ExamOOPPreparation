namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public class House : Estate, IHouse
    {
        private const int MinNumberOfFloors = 0;

        private const int MaxNumberOfFloors = 10;

        private int floors;

        public House()
            : base(EstateType.House)
        {
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }

            set
            {
                if (value < MinNumberOfFloors || value > MaxNumberOfFloors)
                {
                    throw new IndexOutOfRangeException(
                        string.Format(
                            "Number of floors must be between [{0}...{1}]", 
                            MinNumberOfFloors, 
                            MaxNumberOfFloors));
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(", Floors: {0}", this.Floors));

            return sb.ToString();
        }
    }
}