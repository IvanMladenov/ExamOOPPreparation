namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Dreadnought : Starship
    {
        private const int DefaultHealth = 200;

        private const int DefaulDamage = 150;

        private const int DefaultShield = 300;

        private const int DefaultFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShield, DefaulDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            int laserDamage = this.Shields / 2 + this.Damage;
            return new Laser(laserDamage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}