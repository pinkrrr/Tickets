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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using ServerFunctions;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для SeatsMap.xaml
    /// </summary>
    
    public partial class SeatsMap : Window
    {
        static ServerToClient stc = (ServerToClient)Activator.GetObject(typeof(ServerToClient),
                              "tcp://localhost:9090/ServerToClient",
                               WellKnownObjectMode.Singleton);
        private ObservableCollection<Seat> Row1 { get;  set; }
        private ObservableCollection<Seat> Row2 { get;  set; }
        private ObservableCollection<Seat> Row3 { get; set; }
        private static List<Seat> ToSell;
        private List<int> column1 { get; set; }
        private List<int> column2 { get; set; }
        private List<int> column3 { get; set; }

        void RefreshItems() 
        {
            CollectionViewSource.GetDefaultView(Row1).Refresh();
            CollectionViewSource.GetDefaultView(Row2).Refresh();
            CollectionViewSource.GetDefaultView(Row3).Refresh();
        }
        public SeatsMap()
        {
            InitializeComponent();
            Row1 = new ObservableCollection<Seat>();
            Row2 = new ObservableCollection<Seat>();
            Row3 = new ObservableCollection<Seat>();
            ToSell = new List<Seat>();
            column1 = new List<int>();
            column2 = new List<int>();
            column3 = new List<int>();
            TitleText.Text=Cashier.arun.Title;
            DateText.Text = Cashier.arun.Date;
            TimeText.Text = Cashier.arun.Time;
            Cashier.arun.ASeats = Cashier.arun.Seats.Split(',').Select(int.Parse).ToList<int>();
            Cashier.arun.APrices=Regex.Split(Cashier.arun.Prices, "; ").Select(int.Parse).ToList<int>();
            int counter = 0;
            int rowcounter=1;
            for (; rowcounter < 7; column1.Add(rowcounter), rowcounter++) ;
            for (; rowcounter < 13; column2.Add(rowcounter), rowcounter++) ;
            for (; rowcounter < 19; column3.Add(rowcounter), rowcounter++) ;
                for (int j = 0; j < 6; j++)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        Seat seat = new Seat();
                        seat.Number = i;
                        seat.Id = counter;
                        seat.Price = Cashier.arun.APrices[0];
                        seat.Status = Cashier.arun.ASeats[counter];
                        Row1.Add(seat);
                        counter++;
                    }
                }
            for (int j = 0; j < 6; j++)
            {
                for (int i = 1; i <= 20; i++)
                {
                    Seat seat = new Seat();
                    seat.Number = i;
                    seat.Id = counter;
                    seat.Price = Cashier.arun.APrices[1];
                    seat.Status = Cashier.arun.ASeats[counter];
                    Row2.Add(seat);
                    counter++;
                }
            }
            for (int j = 0; j < 6; j++)
            {
                for (int i = 1; i <= 20; i++)
                {
                    Seat seat = new Seat();
                    seat.Number = i;
                    seat.Id = counter;
                    seat.Price = Cashier.arun.APrices[2];
                    seat.Status = Cashier.arun.ASeats[counter];
                    Row3.Add(seat);
                    counter++;
                }
            }
            LeftColumn.ItemsSource = column1;
            LeftColumn1.ItemsSource = column2;
            LeftColumn2.ItemsSource = column3;
            Loggia.ItemsSource = Row1;
            Parterre.ItemsSource = Row2;
            Balcony.ItemsSource = Row3;
            RefreshItems();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var newform = new Cashier();
            newform.Show();
            this.Close();
            
        }
        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Seat seat = ((sender as FrameworkElement).DataContext as Seat);
                if (seat.Status == 0)
                {
                    seat.Status = 1;
                    ToSell.Add(seat);
                    PriceText.Text = Convert.ToString(Int32.Parse(PriceText.Text) + seat.Price);
                    CountText.Text = Convert.ToString(Int32.Parse(CountText.Text) + 1);
                    
                    RefreshItems();
                }
                else if (seat.Status == 1)
                {
                    seat.Status = 0;
                    ToSell.Remove(seat);
                    RefreshItems();
                    PriceText.Text = Convert.ToString(Int32.Parse(PriceText.Text) - seat.Price);
                    CountText.Text = Convert.ToString(Int32.Parse(CountText.Text) - 1);
                }

                else if (seat.Status == 2)
                {
                    seat.Status = 0;
                    RefreshItems();
                }
                else if (seat.Status == 4) { }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }

        }
        private void MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Seat seat = ((sender as FrameworkElement).DataContext as Seat);
            if (seat.Status == 0)
            {
                seat.Status = 2;
                RefreshItems();
            }
            else if (seat.Status == 1)
            {}
            else if (seat.Status == 2)
            {
                seat.Status = 0;
                RefreshItems();
            }
        }
        private void SellClick(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Seat seat in ToSell)
                {
                    seat.Status=4;
                }
                stc.SaveSeatsFromClient(ToSell, Cashier.arun, int.Parse(PriceText.Text), Login.name);
                ToSell.Clear();
                PriceText.Text = "0";
                CountText.Text = "0";
                RefreshItems();
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }
        
    }
}
