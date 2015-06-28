namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Engine.Factories;
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string name = commandArgs[2];
            string locationNmae = commandArgs[3];

            bool shipExist = this.GameEngine.Starships.Any(s => s.Name == name);

            if (shipExist)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationNmae);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            IStarship create = this.GameEngine.ShipFactory.CreateShip(shipType, name, location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancmentType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = null;
                enhancement = this.GameEngine.EnhancementFactory.Create(enhancmentType);
                create.AddEnhancement(enhancement);
            }

            this.GameEngine.Starships.Add(create);

            Console.WriteLine(Messages.CreatedShip,shipType,name);
        }
    }
}
