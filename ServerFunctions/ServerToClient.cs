using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using Models;

namespace ServerFunctions
{
    [Synchronization()]
    public class ServerToClient : ContextBoundObject
    {
        DBFuncs funcs = new DBFuncs();
        public List<Play> GetPlaysToClient(string name)
        {
            List<Play> Plays=new List<Play>();
            Plays = funcs.GetPlays();
            Console.WriteLine("Manager {0} has recieved plays list",name);
            return Plays;
        }

        public List<Run> GetRunsToClient(string name, string date)
        {
            List<Run> Runs = new List<Run>();
            Runs = funcs.GetRuns(date);
            Console.WriteLine("Cashier {0} has recieved plays list for {1}",name,date);
            return Runs;
        }

        public void SavePlayFromClient (Play play, string name)
        {
            funcs.AddPlay(play);
            Console.WriteLine("Manager {1} has uploaded a play {0}",play.Title,name);
        }
        public int GetLoginToClient(string login,string password,string name)
        {
            int access=funcs.GetLogin(login,password);
            if (access == 0)
                Console.WriteLine("User {0} has loged in as cashier", name);
            if (access == 1)
                Console.WriteLine("User {0} has loged in as manager", name);
            if (access == 2)
                Console.WriteLine("Failed attempt to log in");
            return access;
        }
        
        public void SaveRunsFromClient (Play play, string name)
        {
            funcs.SetUpRuns(play);
            Console.WriteLine("Manager {1} has set up runs for play {0}", play.Title,name);
        }
        public void SaveSeatsFromClient (List<Seat> seats,Run run,int price,string name)
        {
            funcs.SaveSeat(seats, run, price);
            
            foreach(Seat seat in seats)
            {
                decimal seatrow = seat.Id / 18;
                Console.WriteLine("Cashier {0} has sold seat {1} in row {5} for play {2} at {3}, {4}", name,seat.Number,run.Title,run.Time,run.Date, Math.Truncate(seatrow));
            }
        }
    }
}
