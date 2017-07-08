using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        static ServerToClient stc = (ServerToClient)Activator.GetObject(typeof(ServerToClient),
                              "tcp://localhost:9090/ServerToClient",
                               WellKnownObjectMode.Singleton);
        public Manager()
        {
            InitializeComponent();
            try
            {
                List<Play> Plays = new List<Play>(); 
                Plays = stc.GetPlaysToClient(Login.name);
                List.ItemsSource = Plays;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var newform = new ManagerPlay();
            newform.Show();
            this.Close();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
                var newform = new Login();
                newform.Show();
                this.Close();
        }

        public void SetupRuns_Click(object sender, RoutedEventArgs e)
        {
            try {
                
                if (List.SelectedItem != null)
                { 
                    Play play = (Play)List.SelectedItem;
                    stc.SaveRunsFromClient(play,Login.name);
                    MessageBox.Show("Runs for "+play.Title+" have been succesfully added");
                }
                else
                    MessageBox.Show("Select a row");
                }
            catch(Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}


