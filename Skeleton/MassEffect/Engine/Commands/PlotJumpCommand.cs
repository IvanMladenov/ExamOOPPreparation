namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string starSystemName = commandArgs[2];

            IStarship ship = this.GameEngine.Starships.FirstOrDefault(x => x.Name == shipName);
            this.ValidateAlive(ship);

            var currentLocation = ship.Location;
            var destination = this.GameEngine.Galaxy.GetStarSystemByName(starSystemName);

            if (currentLocation.Name == destination.Name)
            {
                throw new ShipException(String.Format(Messages.ShipAlreadyInStarSystem,starSystemName));
            }

            this.GameEngine.Galaxy.TravelTo(ship,destination);

            Console.WriteLine(Messages.ShipTraveled,shipName,currentLocation.Name,starSystemName);
        }
    }
}
