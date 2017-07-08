using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Models;
using ServerFunctions;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для Cashier.xaml
    /// </summary>
    public partial class Cashier : Window
    {
        static ServerToClient stc = (ServerToClient)Activator.GetObject(typeof(ServerToClient),
                                 "tcp://localhost:9090/ServerToClient",
                                  WellKnownObjectMode.Singleton);
        public static Run arun = new Run();

        public Cashier()
        {
            InitializeComponent();
            List<Run> Runs=stc.GetRunsToClient(Login.name,DateTime.Now.ToShortDateString());
            RunsGrid.DataContext = Runs;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var newform = new Login();
            newform.Show();
            this.Close();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {

            string date = DateDrop.SelectedDate.Value.ToShortDateString();
            List<Run> Runs = stc.GetRunsToClient(Login.name, date);
            RunsGrid.DataContext = Runs;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (RunsGrid.SelectedItem != null)
                {
                    arun = (Run)RunsGrid.SelectedItem;
                    var newform = new SeatsMap();
                    newform.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Select a run");
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}
