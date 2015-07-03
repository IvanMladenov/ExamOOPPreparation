namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
         }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];
            
            var attackerShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == attackerName);
            var targetShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == targetName);

            this.ValidateAlive(attackerShip);
            this.ValidateAlive(targetShip);

            if (attackerShip.Location != targetShip.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            this.ProcessStarshipBattle(attackerShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attacker, IStarship target)
        {
            this.ValidateAlive(attacker);
            this.ValidateAlive(target);
            this.ValidateSameStarsystem(attacker,target);

            IProjectile projectile = attacker.ProduceAttack();

            target.RespondToAttack(projectile);
            Console.WriteLine(Messages.ShipAttacked,attacker.Name,target.Name);

            if (target.Shields < 0)
            {
                target.Shields = 0;
            }
            if (target.Health < 0)
            {
                target.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed,target.Name);
            }
        }
    }
}
