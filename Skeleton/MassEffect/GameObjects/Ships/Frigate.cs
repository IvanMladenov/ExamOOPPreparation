namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Text;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship
    {
        private const int DefaultHealth = 60;

        private const int DefaulDamage = 30;

        private const int DefaultShield = 50;

        private const int DefaultFuel = 220;

        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShield, DefaulDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                sb.AppendLine();
                sb.Append(string.Format("-Projectiles fired: {0}", this.projectilesFired.ToString()));
            }

            return sb.ToString();
        }
    }
}