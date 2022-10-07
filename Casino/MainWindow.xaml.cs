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
using Core;

namespace Casino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigated += FrameNavigated;
            frame.NavigationService.Navigate(new Pages.LoginPage());
            if (Properties.Settings.Default.Login != "")
            {
                App.User = DataAccess.GetUser(Properties.Settings.Default.Login, Properties.Settings.Default.Password);
                frame.NavigationService.Navigate(new Pages.CasinoPage());
            }
        }
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void btnGoForward_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoForward)
                frame.NavigationService.GoForward();
        }
        private void FrameNavigated(object sender, NavigationEventArgs e)
        {
            if (frame.Content is Pages.LoginPage)
            {
                btnGoBack.Visibility = Visibility.Hidden;
                btnLogout.Visibility = Visibility.Hidden;
            }
            else if (frame.Content is Pages.RegistrationPage)
            {
                btnGoBack.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Hidden;
            }
            else
            {
                btnGoBack.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Visible;
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            frame.NavigationService.Navigate(new Pages.LoginPage());
        }
    }
}
