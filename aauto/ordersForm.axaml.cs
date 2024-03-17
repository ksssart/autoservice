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

public partial class ordersForm : Window
{
    
    private List<orderss> ord;
    private string connStr = "server=localhost;database=autose;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    public ordersForm()
    {
        InitializeComponent();
        string table = "SELECT * FROM orders";
        ShowData(table);
    }

    public void ShowData(string sql)
    {
        ord = new List<orderss>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var ooord = new orderss()
            {
                id = reader.GetInt32("id"),
                client_id = reader.GetInt32("client_id"),
                service_id = reader.GetInt32("service_id"),
                date = reader.GetString("date"),


            };
            ord.Add(ooord);
        }

        conn.Close();
        OrderGrid.ItemsSource = ord;
    }
    
    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            orderss ooord = OrderGrid.SelectedItem as orderss;
            if (ooord == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM orders WHERE id = " + ooord.id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ord.Remove(ooord);
            ShowTable("SELECT id, client_id, service_id, date FROM orders;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowTable(string selectIdClientIdServiceIdDateFromOrders)
    {
        throw new NotImplementedException();
    }

    private void Back(object? sender, RoutedEventArgs e)
    {
        var main = new menu();
        main.Show();
        this.Hide();
    } 
    
    private void AddData(object? sender, RoutedEventArgs e)
    {
        orderss newOrd = new orderss();
        aauto.addOrder add = new aauto.addOrder(newOrd, ord);
        add.Show();
        this.Hide();
    }
    
    private void EditData(object? sender, RoutedEventArgs e)
    {
        orderss ooord = OrderGrid.SelectedItem as orderss;
        if (ooord == null)
        {
            return;
        }

        aauto.addOrder add = new aauto.addOrder(ooord, ord);
        add.Show();
        this.Hide();
    }


}