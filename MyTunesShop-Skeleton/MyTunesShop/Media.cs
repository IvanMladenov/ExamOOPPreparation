using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesShop
{
    public abstract class Media:IMedia,IRateable
    {
        private static readonly int MinYear = DateTime.MinValue.Year;
        private static readonly int MaxYear = DateTime.Now.Year;

        private bool rateble = true;
        private int year;
        private string title;
        private string genre;
        private decimal price;
        private IPerformer performer;

        public Media(string title,decimal price,IPerformer performer,string genre, int year)
        {
            this.Performer = performer;
            this.Genre = genre;
            this.Year = year;
            this.Price = price;
            this.Title = title;
            this.Ratings=new List<int>();
        }

        public bool Rateble
        {
            get
            {
                return this.rateble;
            }
            private set
            {
                if (!value)
                {
                    throw new ArgumentException("The song must be rateable.");
                }

                this.rateble = value;
            }
        }

        public IList<int> Ratings { get; private set; }

        public string Genre
        {
            get
            {
                return this.genre;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The genre of a song is required.");
                }

                this.genre = value;
            }
        }

        public IPerformer Performer
        {
            get
            {
                return this.performer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The performer of a song is required.");
                }

                this.performer = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The title of a song is required.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price of a song must be non-negative.");
                }

                this.price = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value < MinYear || value > MaxYear)
                {
                    throw new ArgumentException(string.Format("The year of a song must be between {0} and {1}.", MinYear, MaxYear));
                }

                this.year = value;
            }
        }

        public void PlaceRating(int rating)
        {
            this.Ratings.Add(rating);
        }
    }
}
