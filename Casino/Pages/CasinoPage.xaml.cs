using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Threading.Tasks;
using Core;

namespace Casino.Pages
{
    /// <summary>
    /// Interaction logic for CasinoPage.xaml
    /// </summary>
    public partial class CasinoPage : Page
    {
        public CasinoPage()
        {
            InitializeComponent();
            DataContext = App.User;
        }

        private async void BtnStartCasino_Click(object sender, RoutedEventArgs e)
        {
            if (App.User.Point <= 0)
            {
                MessageBox.Show("Недостаточко очков");
                return;
            }

            var rnd = new Random();

            await Task.Run(() => {

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Dispatcher.Invoke(() => { 
                        leftDrum.Text = rnd.Next(1, 6).ToString();
                        leftImage.Source = new BitmapImage(new Uri($"/Images/{leftDrum.Text}.png", UriKind.Relative));

                        centerDrum.Text = rnd.Next(1, 6).ToString();
                        centerImage.Source = new BitmapImage(new Uri($"/Images/{centerDrum.Text}.png", UriKind.Relative));

                        rightDrum.Text = rnd.Next(1, 6).ToString();
                        rightImage.Source = new BitmapImage(new Uri($"/Images/{rightDrum.Text}.png", UriKind.Relative));
                    });
                }
                Dispatcher.Invoke(() =>
                {
                    if (leftDrum.Text == centerDrum.Text && centerDrum.Text == rightDrum.Text)
                    {
                        MessageBox.Show("+1000");
                        App.User.Point += 1000;
                    }
                    else if (leftDrum.Text == centerDrum.Text ||
                            leftDrum.Text == rightDrum.Text ||
                            centerDrum.Text == rightDrum.Text)
                    {
                        MessageBox.Show("+100");
                        App.User.Point += 100;
                    }
                    else
                    {
                        MessageBox.Show("-10");
                        App.User.Point -= 10;
                    }
                    DataAccess.SaveUser(App.User);
                    DataContext = App.User;
                    TbPoint.Text = App.User.Point.ToString();
                });
            });
        }
    }
}
