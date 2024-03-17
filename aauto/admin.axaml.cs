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

public partial class admin : Window
{
    private List<ssservice> serv;
    private string connStr = "server=localhost;database=autose;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public admin()
    {
        InitializeComponent();
        string table = "SELECT * FROM service";
        ShowData(table);
        FillDostList();
    }
    
    public void ShowData(string sql)
    {
        serv = new List<ssservice>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var ssserv = new ssservice()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                price = reader.GetInt32("price"),
                discount = reader.GetInt32("discount"),
                price_discount = reader.GetInt32("price_discount"),
                time_minutes = reader.GetInt32("time_minutes"),
                photo= LoadImage("avares://aauto/image/" + reader.GetString( column: "photo"))
            };
            serv.Add(ssserv);
        }

        conn.Close();
        ServiceGrid.ItemsSource = serv;
    }

    public Bitmap LoadImage(string Uri)
    {
        return new Bitmap(stream: AssetLoader.Open(new Uri(Uri)));
    }
    
    private void Ssearch(object? sender, TextChangedEventArgs e)
    {
        var servv = serv;
        servv = servv.Where(x => x.name.Contains(Search.Text)).ToList();
        ServiceGrid.ItemsSource = servv;
    }
    
    private void Cmb_Dost(object? sender, SelectionChangedEventArgs e)
    {
        var ser = (ComboBox)sender;
        var currentSer = ser.SelectedItem as ssservice;
        var filtrSer = serv
            .Where(x => x.discount == currentSer.discount)
            .ToList();
        ServiceGrid.ItemsSource = filtrSer;
    }
    
    public void FillDostList()
    {
        serv = new List<ssservice>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand("select * from service", conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var currentSer = new ssservice()
            {
                id = reader.GetInt32("id"),
                name = reader.GetString("name"),
                price = reader.GetInt32("price"),
                discount = reader.GetInt32("discount"),
                price_discount = reader.GetInt32("price_discount"),
                time_minutes = reader.GetInt32("time_minutes"),
                photo= LoadImage("avares://aauto/image/" + reader.GetString( column: "photo")),
                
            };
            serv.Add(currentSer);
        }

        conn.Close();
        var sercmb = this.Find<ComboBox>(name: "CmbDost");
        sercmb.ItemsSource = serv;
    }
    
    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            ssservice ssser = ServiceGrid.SelectedItem as ssservice;
            if (ssser == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM service WHERE id = " + ssser.id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            serv.Remove(ssser);
            ShowTable("SELECT id, name, price, discount, price_discount, time_minutes, photo FROM service;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void Back(object? sender, RoutedEventArgs e)
    {
        var main = new menu();
        main.Show();
        this.Hide();
    } 
    
    private void AddData(object? sender, RoutedEventArgs e)
    {
        ssservice newServ = new ssservice();
        aauto.add add = new aauto.add(newServ, serv);
        add.Show();
        this.Hide();
    }
    
    private void EditData(object? sender, RoutedEventArgs e)
    {
        ssservice ssser = ServiceGrid.SelectedItem as ssservice;
        if (ssser == null)
        {
            return;
        }

        aauto.add add = new aauto.add(ssser, serv);
        add.Show();
        this.Hide();
    }
    
    
    private void ShowTable(string selectIdNamePriceDiscountPriceDiscountTimeMinutesPhotoFromService)
    {
        throw new NotImplementedException();
    }
}