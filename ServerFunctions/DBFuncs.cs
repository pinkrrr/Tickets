using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using Models;
using System.Text.RegularExpressions;


namespace ServerFunctions
{
    public class DBFuncs : DbContext
    {
        
        public DBFuncs() : base("TicketsDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DBFuncs>());
            //Database.SetInitializer<DBFuncs>(new DropCreateDatabaseAlways<DBFuncs>());
        }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<User> Users { get; set; }
        
        public List<Play> GetPlays()
        {
            DBFuncs funcs = new DBFuncs();
            funcs.Plays.Load();
            List<Play> Plays = new List<Play>();
            foreach (Play play in funcs.Plays.Local) 
            { 
                Plays.Add(play); 
            }
            return Plays;

        }
        public List<Run> GetRuns(string date)
            {
                DBFuncs funcs = new DBFuncs();
                List<Run> runs = new List<Run>();
                IEnumerable<Run> RunsENum = funcs.Runs
               .Where(run => run.Date == date)
               .OrderBy(run => run.Time)
               .AsEnumerable()
               .Select(an => new Run
               {
                   Id=an.Id,
                   Title=an.Title,
                   Date=an.Date,
                   Time=an.Time,
                   Seats=an.Seats,
                   Prices=an.Prices,
                   Income=an.Income
               });
                foreach (Run run in RunsENum)
                    runs.Add(run);
                return runs;
                
            }
        public void AddPlay(Play play)
        {
            DBFuncs funcs = new DBFuncs();
            funcs.Plays.Add(play);
            funcs.SaveChanges();
        }

        public int GetLogin(string login, string password)
        {
            DBFuncs funcs = new DBFuncs();
            User user = new User();
                user = funcs.Users.FirstOrDefault(c =>
                        c.Login == login);
                if (user != null)
                {
                    if (user.Password == password && user.Access == 0)
                        return 0;
                    if (user.Password == password && user.Access == 1)
                        return 1;
                    else return 2;
                }
                else return 2;

        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public void SetUpRuns(Play play)
        {
            DBFuncs funcs = new DBFuncs();
            Run run = new Run();
            DateTime datestart = Convert.ToDateTime(play.DateStart);
            DateTime dateend = Convert.ToDateTime(play.DateEnd);
            List<string> listdays = Regex.Split(play.Days, "; ").ToList<string>();
            List<string> listtime = Regex.Split(play.Time, "; ").ToList<string>();
            run.ASeats = new List<int>();
            for (int i = 0; i < 360; i++)
            { run.ASeats.Add(0); }
            foreach (string dayofweek in listdays)
            {
                foreach (DateTime datetime in EachDay(datestart, dateend))
                {
                    if (datetime.DayOfWeek.ToString() == dayofweek)
                        foreach (string time in listtime)
                        {
                            
                            run.Title = play.Title;
                            run.Date = datetime.ToShortDateString();
                            run.Time = time;
                            run.Seats = string.Join(",", run.ASeats);
                            run.Income = 0;
                            run.Prices = play.Prices;
                            funcs.Runs.Add(run);
                            funcs.SaveChanges();
                         }
                    }
                }
            }
        public void SaveSeat(List<Seat> seats,Run run,int price)
        {
            DBFuncs funcs = new DBFuncs();
            Run dbrun = funcs.Runs.FirstOrDefault(c =>
                        c.Id == run.Id);
            dbrun.ASeats = dbrun.Seats.Split(',').Select(int.Parse).ToList<int>();
            foreach (Seat seat in seats)
            {
                dbrun.ASeats[seat.Id] = seat.Status;
            }
            string temp = string.Join(",", dbrun.ASeats);
            dbrun.Seats = temp;
            dbrun.Income += price;
            funcs.SaveChanges();
        }
            
        }
    }
  
