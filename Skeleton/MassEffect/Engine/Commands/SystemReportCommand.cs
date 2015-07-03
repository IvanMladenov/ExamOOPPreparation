namespace MassEffect.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MassEffect.Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string name = commandArgs[1];

            var location = this.GameEngine.Galaxy.GetStarSystemByName(name);

            var shipsInSystem = this.GameEngine.Starships.Where(x => x.Location == location);

            var collectionOfOrderedShips = shipsInSystem.Where(x => x.Health > 0)
                .OrderByDescending(x => x.Health)
                .ThenByDescending(x=>x.Shields);

            var sb = new StringBuilder();
            sb.AppendLine("Intact ships:");
            sb.AppendLine(collectionOfOrderedShips.Any() ? string.Join("\n", collectionOfOrderedShips) : "N/A");

            var collectionOfDestroyedShips = shipsInSystem.Where(x => x.Health == 0).OrderBy(x=>x.Name);

            sb.AppendLine("Destroyed ships:");
            sb.Append(collectionOfDestroyedShips.Any() ? string.Join("\n", collectionOfDestroyedShips) : "N/A");

            Console.WriteLine(sb.ToString());
        }
    }
}