namespace Estates.Data
{
    using System.Linq;

    using Estates.Engine;
    using Estates.Interfaces;

    internal class EstateEngineExtended : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.FindRentsByLocation(cmdArgs[0]);

                case "find-rents-by-price":
                    return this.FindRentsByPrice(cmdArgs[0], cmdArgs[1]);

                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string FindRentsByPrice(string minPrice, string maxPrice)
        {
            var offers =
                this.Offers.Where(x => x.Type == OfferType.Rent)
                    .Cast<IRentOffer>()
                    .Where(x => x.PricePerMonth >= decimal.Parse(minPrice))
                    .Where(x => x.PricePerMonth <= decimal.Parse(maxPrice))
                    .OrderBy(x => x.PricePerMonth)
                    .ThenBy(x => x.Estate.Name);
            return this.FormatQueryResults(offers);
        }

        private string FindRentsByLocation(string location)
        {
            var offers =
                this.Offers.Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                    .OrderBy(o => o.Estate.Name);
            return this.FormatQueryResults(offers);
        }
    }
}