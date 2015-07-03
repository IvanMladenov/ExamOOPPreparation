namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public class Garage : Estate, IGarage
    {
        private const int MinValue = 0;

        private const int MaxValue = 500;

        private int heght;

        private int width;

        public Garage()
            : base(EstateType.Garage)
        {
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Width must be between [{0}...{1}]", MinValue, MaxValue));
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.heght;
            }

            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Height must be between [{0}...{1}]", MinValue, MaxValue));
                }

                this.heght = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(", Width: {0}, Height: {1}", this.Width, this.Height));

            return sb.ToString();
        }
    }
}