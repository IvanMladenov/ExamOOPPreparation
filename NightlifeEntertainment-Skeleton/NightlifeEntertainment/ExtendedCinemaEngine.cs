namespace NightlifeEntertainment
{
    using System;
    using System.Linq;
    using System.Text;

    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportHall = new SportHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);

            if (venue == null)
            {
                throw new ArgumentNullException("Venue doesn`t exist.");
            }

            switch (commandWords[2])
            {
                case "theatre":
                    
                    var theatre = new Theather(
                        commandWords[3], 
                        decimal.Parse(commandWords[4]), 
                        venue, 
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(
                        commandWords[3], 
                        decimal.Parse(commandWords[4]), 
                        venue, 
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.Performances.FirstOrDefault(x => x.Name == commandWords[1]);

            if (performance == null)
            {
                throw new NullReferenceException("No performance with this name.");
            }

            var soldTickets = performance.Tickets.Where(x => x.Status == TicketStatus.Sold).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "{0}: {1} ticket(s), total: ${2:F2}", 
                performance.Name, 
                soldTickets.Count(), 
                soldTickets.Sum(x => x.Price)).AppendLine();
            sb.AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location).AppendLine();
            sb.AppendFormat("Start time: {0}", performance.StartTime).AppendLine();

            this.Output.Append(sb);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string wordToSearch = commandWords[1].ToLower();
            DateTime inputTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            var performances =
                this.Performances.Where(x => x.Name.ToLower().Contains(wordToSearch))
                    .Where(x => x.StartTime >= inputTime)
                    .OrderBy(x => x.StartTime)
                    .ThenByDescending(x => x.BasePrice)
                    .ThenBy(x => x.Name);
            var venues = this.Venues.Where(x => x.Name.ToLower().Contains(wordToSearch)).OrderBy(x => x.Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Search for \"{0}\"", commandWords[1]).AppendLine();
            sb.AppendLine("Performances:");
            if (performances.Count()==0)
            {
                sb.AppendLine("no results");
            }
            else
            {
                foreach (var performance in performances)
                {
                    sb.AppendLine("-" + performance.Name);
                }
            }

            sb.AppendLine("Venues:");
            if (venues.Count()==0)
            {
                sb.AppendLine("no results");
            }
            else
            {
                foreach (var venue in venues)
                {
                    sb.AppendLine(string.Format("-{0}", venue.Name));
                    var venue1 = venue;
                    var evennts =
                        this.Performances.Where(x => x.Venue == venue1)
                            .Where(x => x.StartTime >= inputTime)
                            .OrderBy(x => x.StartTime)
                            .ThenByDescending(x => x.BasePrice)
                            .ThenBy(x => x.Name);
                    if (evennts.Any())
                    {
                        foreach (var performance in evennts)
                        {
                            sb.AppendLine(string.Format("--{0}", performance.Name));
                        }
                    }
                }
            }

            this.Output.Append(sb);
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);

            if (venue == null || performance == null || !venue.AllowedTypes.Contains(performance.Type))
            {
                throw new ArgumentException("Invalid venue or performance.");
            }

            if (performance.Tickets.Count >= venue.Seats)
            {
                throw new InvalidOperationException("There are no seats left for this performance.");
            }
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }
    }
}