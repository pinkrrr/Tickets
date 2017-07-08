using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Models
{
    [Serializable]
    public class Run
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public List<int> ASeats { get; set; }
        public List<int> APrices { get; set; }

        public string Seats { get; set; }

        public string Prices { get; set; }
        public double Income { get; set; }
    }
}
