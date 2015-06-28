namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public abstract class Starship : IStarship
    {
        private readonly IList<Enhancement> enhansments;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Location = location;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.enhansments = new List<Enhancement>();
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhansments;
            }
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhansment cannot be null");
            }

            this.enhansments.Add(enhancement);

            this.Fuel += enhancement.FuelBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("--{0} - {1}", this.Name, this.GetType().Name).AppendLine();
            if (this.Health == 0)
            {
                sb.Append("(Destroyed)");
            }
            else
            {
                sb.AppendLine(string.Format("-Location: {0}", this.Location));
                sb.AppendLine(string.Format("-Health: {0}", this.Health));
                sb.AppendLine(string.Format("-Shields: {0}", this.Shields));
                sb.AppendLine(string.Format("-Damage: {0}", this.Damage));
                sb.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                sb.Append(
                    string.Format(
                        "-Enhancements: {0}", 
                        this.Enhancements.Any() ? string.Join(", ", this.Enhancements) : "N/A"));
            }

            return sb.ToString();
        }
    }
}