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
            if (ship.Shields > this.Damage)
            {
                ship.Shields -= this.Damage;
            }
            else
            {
                int damageLeft = this.Damage - ship.Shields;
                ship.Shields = 0;
                ship.Health -= damageLeft;
            }
        }
    }
}