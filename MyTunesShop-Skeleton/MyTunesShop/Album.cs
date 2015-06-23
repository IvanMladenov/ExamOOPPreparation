using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesShop
{
    public class Album:Media,IAlbum
    {

        public Album(string title, decimal price, IPerformer performer, string genre, int year)
            : base(title, price, performer, genre, year)
        {
            this.Songs=new List<ISong>();
        }
       


        public IList<ISong> Songs { get; private set; }

        public void AddSong(ISong song)
        {
            Songs.Add(song);
        }

        
    }
}
