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
using ClientFunctions;
using ServerFunctions;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для ManagerPlay.xaml
    /// </summary>
    public partial class ManagerPlay : Window
    {
        public ManagerPlay()
        {
            InitializeComponent();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                Play play = new Play();
                MCFunctions cf = new MCFunctions();
                play.Title = PlayTitle.Text;
                play.DateStart = DateStart.SelectedDate.Value.Date.ToShortDateString();
                play.DateEnd = DateEnd.SelectedDate.Value.Date.ToShortDateString();
                play.Days = cf.CheckboxDayReturn(Day0.IsChecked.Value, 
                    Day1.IsChecked.Value, 
                    Day2.IsChecked.Value, 
                    Day3.IsChecked.Value, 
                    Day4.IsChecked.Value, 
                    Day5.IsChecked.Value, 
                    Day6.IsChecked.Value, 
                    Day7.IsChecked.Value);
                play.Time = cf.CheckboxTimeReturn(Time0.IsChecked.Value,
                    Time1.IsChecked.Value,
                    Time2.IsChecked.Value,
                    Time3.IsChecked.Value,
                    Time4.IsChecked.Value);
                play.Prices = cf.PricesStringReturn(Price0.Text, Price1.Text, Price2.Text);
                if(PlayTitle.Text.Length==0 || Price0.Text.Length==0 || Price1.Text.Length==0 || Price2.Text.Length==0)
                {
                    MessageBox.Show("Fill empty elements");
                }
                else
                {
                        ServerToClient stc = (ServerToClient)Activator.GetObject(typeof(ServerToClient),
                                  "tcp://localhost:9090/ServerToClient",
                                   WellKnownObjectMode.Singleton);
                        stc.SavePlayFromClient(play, Login.name);
                    MessageBox.Show("Play has been succesfully added");
                    var newform = new Manager();
                    newform.Show();
                    this.Close();
                }
            }
            catch(Exception b)
            {
                MessageBox.Show(b.Message);   
            }
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            var newform = new Manager();
            newform.Show();
            this.Close();
        }
    }
}
