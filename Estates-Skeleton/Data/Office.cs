namespace Estates.Data
{
    using Estates.Interfaces;

    public class Office : BuildingEstate, IOffice
    {
        public Office()
            : base(EstateType.Office)
        {
        }
    }
}