using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}
