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
            frame.NavigationService.Navigate(new Pages.LoginPage());
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
                btnGoForward.Visibility = Visibility.Hidden;
                btnGoBack.Visibility = Visibility.Hidden;
            }
            else if (frame.Content is Pages.RegistrationPage)
            {
                btnGoForward.Visibility = Visibility.Hidden;
                btnGoBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnGoBack.Visibility = Visibility.Visible;
                btnGoForward.Visibility = Visibility.Visible;
            }
        }
    }
}
