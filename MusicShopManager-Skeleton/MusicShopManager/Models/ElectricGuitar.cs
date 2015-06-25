namespace MusicShop.Models
{
    using System;
    using System.Text;

    using MusicShopManager.Interfaces;

    internal class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;

        private int numberOfFrets;

        public ElectricGuitar(
            string make, 
            string model, 
            decimal price, 
            string color, 
            string bodyWood, 
            string fingerboardWood, 
            int numberOfAdapters, 
            int numberOfFrets)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get
            {
                return this.numberOfAdapters;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of adapters of an electronic guitar must be non-negative.");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of frets of an electronic guitar must be non-negative.");
                }

                this.numberOfFrets = value;
            }
        }

        public override bool IsElectronic
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendFormat("Adapters: {0}", this.NumberOfAdapters).AppendLine();
            sb.AppendFormat("Frets: {0}", this.NumberOfFrets).AppendLine();

            return sb.ToString();
        }
    }
}