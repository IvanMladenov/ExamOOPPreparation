namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ExtendedEngine : MyTunesEngine
    {
        protected override void ExecuteRateCommand(string[] commandWords)
        {
            string songName = commandWords[2];
            var song = this.media.FirstOrDefault(s => s is Song && s.Title == songName) as Song;
            if (song == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
                return;
            }

            int rating = int.Parse(commandWords[3]);
            song.PlaceRating(rating);
            this.Printer.PrintLine("The rating has been placed successfully.");
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        protected override string GetSongReport(ISong song)
        {
            int avgRating = 0;
            if (song.Ratings.Count > 0)
            {
                avgRating = (int)Math.Round(song.Ratings.Average());
            }
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name)
                .AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price)
                .AppendLine()
                .AppendFormat("Rating: {0}", avgRating).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3], 
                        decimal.Parse(commandWords[4]), 
                        performer, 
                        commandWords[6], 
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    string songName = commandWords[3];
                    var song = this.media.FirstOrDefault(s => s is Song && s.Title == songName) as Song;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    string albumName = commandWords[2];
                    var album = this.media.FirstOrDefault(a => a is Album && a.Title == albumName) as Album;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    album.AddSong(song);
                    this.Printer.PrintLine("The song {0} has been added to the album {1}.", song.Title, album.Title);

                    break;

                case "member_to_band":
                    var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[2]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    band.AddMember(commandWords[3]);
                    this.Printer.PrintLine("The member {0} has been added to the band {1}.", commandWords[3], band.Name);
                    break;

                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int albumQuantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(albumQuantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", albumQuantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int albumQuantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(albumQuantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", albumQuantity, album.Title);
                    break;

                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "singer":
                    var singer = this.performers.FirstOrDefault(p => p is Singer && p.Name == commandWords[3]) as Singer;
                    if (singer == null)
                    {
                        this.Printer.PrintLine("The singer does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetSingerReport(singer));
                    break;
                case "band":
                    var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        private string GetBandReport(Band band)
        {
            StringBuilder bandInfo = new StringBuilder();
            bandInfo.AppendFormat(band.Name + ": ");
            if (band.Members.Count > 0)
            {
                bandInfo.Append(string.Join(", ", band.Members));
            }

            bandInfo.AppendLine();
            if (band.Songs.Count > 0)
            {
                List<string>songTitles=new List<string>();
                foreach (var name in band.Songs)
                {
                    songTitles.Add(name.Title);
                }
                songTitles.Sort();
                bandInfo.Append(string.Join("; ", songTitles));
            }
            else
            {
                bandInfo.Append("no songs");
            }

            return bandInfo.ToString();
        }

        private void InsertAlbum(IAlbum album)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album,new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, album.Performer.Name);
        }

        protected string GetAlbumReport(IAlbum album)
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine();
            output.AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine();

            var albumSalesInfo = this.mediaSupplies[album];

            output.AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold)
                .AppendLine();
            if (album.Songs.Count == 0)
            {
                output.AppendFormat("No songs");//.AppendLine();
            }
            else 
            {
                output.AppendLine("Songs:");
                List<string>names=new List<string>();
                for (int i = 0; i < album.Songs.Count; i++)
                {
                    names.Add(string.Format("{0} ({1})", album.Songs[i].Title, album.Songs[i].Duration));
                }
                output.Append(string.Join("\n", names));
            }

            return output.ToString();
        }
    }
}