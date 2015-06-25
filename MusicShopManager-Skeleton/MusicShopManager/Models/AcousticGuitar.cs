// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AcousticGuitar.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MusicShop.Models
{
    using System.Text;

    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;

    public class AcousticGuitar:Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, 
            string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }

        public StringMaterial StringMaterial { get; private set; }

        public override bool IsElectronic
        {
            get
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(base.ToString());
            sb.AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no").AppendLine();
            sb.AppendFormat("String material: {0}", this.StringMaterial.ToString()).AppendLine();

            return sb.ToString();
        }
    }
}
