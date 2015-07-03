namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string name = commandArgs[1];
            var ship = this.GameEngine.Starships.FirstOrDefault(x => x.Name == name);

            if (ship == null)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }
            Console.WriteLine(ship.ToString());
        }
    }
}