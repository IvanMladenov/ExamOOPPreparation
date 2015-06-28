namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        public void ValidateAlive(IStarship ship)
        {
            if (ship.Health < 0)
            {
                throw new ShipException(Messages.ShipDestroyed);
            }
        }

        protected void ValidateSameStarsystem(IStarship firstStarship, IStarship secondStarship)
        {
            if (firstStarship.Location.Name != secondStarship.Location.Name)
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }
        }
    }
}
