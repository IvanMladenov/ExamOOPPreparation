namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Song : Media,ISong
    {
       
        private string duration;

        public Song(string title, decimal price,IPerformer performer,string genre, int year, string duration)
            : base(title, price, performer, genre, year)
        {
            this.Duration = duration;
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The duration of a song is required.");
                }

                this.duration = value;
            }
        }

       
    }
}
