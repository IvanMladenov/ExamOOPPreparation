namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Cruiser : Starship
    {
        private const int DefaultHealth = 100;

        private const int DefaulDamage = 50;

        private const int DefaultShield = 100;

        private const int DefaultFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShield, DefaulDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}