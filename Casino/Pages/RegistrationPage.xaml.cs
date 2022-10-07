﻿using System;
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
using Core;

namespace Casino.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var passwrod = pbPassword.Password;
            var user = new User { Login = login, Password = passwrod, Point = 100 };
            if (DataAccess.SaveUser(user))
            {
                App.User = user;
                NavigationService.Navigate(new CasinoPage());
            }
            else
            {
                MessageBox.Show("Такой пользователь уже зарегистрирован");
            }
        }
    }
}
