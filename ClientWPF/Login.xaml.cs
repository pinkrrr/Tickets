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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerFunctions;

namespace ClientWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class Login : Window
    {
        private static bool namegiven=false;
        public static string name = null;
        ServerToClient stc = (ServerToClient)Activator.GetObject(typeof(ServerToClient),
                                          "tcp://localhost:9090/ServerToClient",
                                           WellKnownObjectMode.Singleton);
        public Login()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Length == 0 || Password.Password.Length == 0)
                MessageBox.Show("Fill empty boxes");
            else
            {
                try
                {
                    string login = Username.Text;
                    string password = Password.Password;
                        name = login;
                    int access = stc.GetLoginToClient(login, password,name);
                    if (access == 1)
                    {
                        var newform = new Manager();
                        newform.Show();
                        this.Close();
                    }
                    if (access == 0)
                    {
                        var newform = new Cashier();
                        newform.Show();
                        this.Close();
                        
                        
                    }
                    if (access == 2)
                        MessageBox.Show("Login Failed");
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }
            }
        }
    }
}
