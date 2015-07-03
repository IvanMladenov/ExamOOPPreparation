namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    internal class Laser : Projectile
    {
         public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int remainderDamage = this.Damage - ship.Shields;
            ship.Shields -= this.Damage;

            if (remainderDamage > 0)
            {
                ship.Health -= remainderDamage;
            }
        }
    }
}