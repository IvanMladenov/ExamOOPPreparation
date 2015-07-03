namespace Estates.Data
{
    using System;
    using System.Text;

    using Estates.Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int MinRoomsCount = 0;

        private const int MaxRoomsCount = 20;

        private int rooms;

        protected BuildingEstate(EstateType type)
            : base(type)
        {
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }

            set
            {
                if (value < MinRoomsCount || value > MaxRoomsCount)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Number of rooms must be between [{0}...{1}]", MinRoomsCount, MaxRoomsCount));
                }

                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            string elevator = this.HasElevator ? "Yes" : "No";
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, elevator));

            return sb.ToString();
        }
    }
}