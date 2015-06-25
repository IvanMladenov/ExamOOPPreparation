using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    public class MusicShop:IMusicShop
    {
        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles=new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cant be null or empty.");
                }
                this.name = value;
            }
        }

        public IList<IArticle> Articles { get; private set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name);
            sb.AppendLine();
            if (!this.Articles.Any())
            {
                sb.AppendLine("The shop is empty. Come back soon.");
                return sb.ToString();
            }
           

            var microphones = this.Articles.Where(m => m is Microphone);
            sb.Append(this.OutputFormat(microphones, "Microphones"));

            var drums = this.Articles.Where(d => d is Drum);
            sb.Append(this.OutputFormat(drums, "Drums"));

            var electricGuitars = this.Articles.Where(e => e is ElectricGuitar);
            sb.Append(this.OutputFormat(electricGuitars, "Electric guitars"));

            var acousticGuitars = this.Articles.Where(x => x is AcousticGuitar);
            sb.Append(this.OutputFormat(acousticGuitars,"Acoustic guitars"));

            var bassGuitars = this.Articles.Where(b => b is BassGuitar);
            sb.Append(this.OutputFormat(bassGuitars, "Bass guitars"));

            return sb.ToString();

        }

        private string OutputFormat(IEnumerable<IArticle> article, string item)
        {
            if (article.Count() == 0)
            {
                return String.Empty;
            }
            StringBuilder format=new StringBuilder();
            article = article.OrderBy(x => x.Make + " " + x.Model);
            format.AppendFormat("{0} {1} {0}", new string('-', 5), item).AppendLine();
            foreach (var part in article)
            {
                format.Append(part.ToString());
            }
            return format.ToString();
        }
    }
}
