using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Play
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Days { get; set; }
        public string Time { get; set; }
        public string Prices { get; set; }
    }
}
