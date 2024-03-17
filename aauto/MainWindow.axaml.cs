using Avalonia.Controls;
using Avalonia;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;


namespace aauto;

public partial class MainWindow : Window
{
    private void login(object? sender, RoutedEventArgs e)
    {
        if (password.Text == "1234") // Здесь можно задать правильный пароль
        {
            // Открыть вторую форму
            var adm = new menu();
            adm.Show();
            this.Hide();
        }
        
    }
    public MainWindow()
    {
        InitializeComponent();
    }
}