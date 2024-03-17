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

public partial class add : Window
{
    private List<ssservice> Ssser;
    private string connStr = "server=localhost;database=autose;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    private ssservice Serv;
    
    public add(ssservice sssotr, List<ssservice> serv)
    {
        InitializeComponent();
        Serv = sssotr;
        this.DataContext = Serv;
        Ssser = serv;
    }
    
    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var zzz = Ssser.FirstOrDefault(x => x.id == Serv.id);
        if (zzz == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add = "INSERT INTO service (id, name, price, discount, price_discount, time_minutes, photo) VALUES (" + Convert.ToInt32(id.Text) + ",'"+ name.Text + "'," + Convert.ToInt32(price.Text) + ", " + Convert.ToInt32(discount.Text) + ", " + Convert.ToInt32(price_discount.Text) + ", " + Convert.ToInt32(time_minutes.Text) + ", '"+ photo.Text + "')";
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
                string upd = "UPDATE service SET name = '" + name.Text + "', ," + Convert.ToInt32(price.Text) + ", " + Convert.ToInt32(discount.Text) + ", " + Convert.ToInt32(price_discount.Text) + ", " + Convert.ToInt32(time_minutes.Text) + ", '"+ photo.Text + "' WHERE id = " + Convert.ToInt32(id.Text) + ";";
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
        var adm = new admin();
        adm.Show();
        this.Hide();
    }
    public add()
    {
        InitializeComponent();
    }
}