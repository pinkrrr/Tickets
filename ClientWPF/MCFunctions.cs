using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Models;

namespace ClientFunctions
{
    public class MCFunctions
    {
        
        public string CheckboxDayReturn(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h)
        {
            string days = null;
            if (a)
                days += DayOfWeek.Monday.ToString() + "; ";
            if (b)
                days += DayOfWeek.Tuesday.ToString() + "; ";
            if (c)
                days += DayOfWeek.Wednesday.ToString() + "; ";
            if (d)
                days += DayOfWeek.Thursday.ToString() + "; ";
            if (e)
                days += DayOfWeek.Friday.ToString() + "; ";
            if (f)
                days += DayOfWeek.Saturday.ToString() + "; ";
            if (g)
                days += DayOfWeek.Sunday.ToString() + "; ";
            if (h)
                days = DayOfWeek.Monday.ToString() + "; " +
                    DayOfWeek.Tuesday.ToString() + "; " +
                    DayOfWeek.Wednesday.ToString() + "; " +
                    DayOfWeek.Thursday.ToString() + "; " +
                    DayOfWeek.Friday.ToString() + "; " +
                    DayOfWeek.Saturday.ToString() + "; " +
                    DayOfWeek.Sunday.ToString() + "; ";
            int dlenght = days.Length - 2;
            return days = days.Remove(dlenght);
        }
        public string CheckboxTimeReturn(bool a, bool b,bool c,bool d,bool e)
        {
            string time = null;
            if (a)
                time += "10:00; ";
            if (b)
                time += "12:00; ";
            if (c)
                time += "14:00; ";
            if (d)
                time += "16:00; ";
            if (e)
                time += "18:00; ";
            int tlenght = time.Length - 2;
            return time = time.Remove(tlenght);
        }
        public string PricesStringReturn(string a, string b, string c)
        {
            string prices = null;
            prices = a + "; " + b + "; " + c;
            return prices;
        }
    }
}
