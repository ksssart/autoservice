using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using Avalonia.Media;
using Avalonia.Controls;
using System.IO;
using System.Windows;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Utilities;
using System;
using System.Globalization;
using Avalonia.Platform;

namespace aauto;

public partial class addOrder : Window
{
    private List<orderss> Ooord;
    private string connStr = "server=localhost;database=autose;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    private orderss Ord;
    
    public addOrder()
    {
        InitializeComponent();
    }
    
    public addOrder(orderss ooord, List<orderss> ord)
    {
        InitializeComponent();
        Ord = ooord;
        this.DataContext = Ord;
        Ooord = ord;
    }
    
    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var zzz = Ooord.FirstOrDefault(x => x.id == Ord.id);
        if (zzz == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add = "INSERT INTO orders (id, client_id, service_id, date) VALUES (" + Convert.ToInt32(id.Text) + "," + Convert.ToInt32(client_id.Text) + ", " + Convert.ToInt32(service_id.Text) + ",'"+ date.Text + "')";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string upd = "UPDATE orders SET name = '" + Convert.ToInt32(client_id.Text) + ", " + Convert.ToInt32(service_id.Text) + ", '"+ date.Text + "' WHERE id = " + Convert.ToInt32(id.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }
    
    private void GoBack(object? sender, RoutedEventArgs e)
    {
        var adm = new ordersForm();
        adm.Show();
        this.Hide();
    }
}