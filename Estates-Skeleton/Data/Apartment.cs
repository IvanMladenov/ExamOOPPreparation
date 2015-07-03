namespace Estates.Data
{
    using System.Text;

    using Estates.Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
            : base(EstateType.Apartment)
        {
        }
    }
}