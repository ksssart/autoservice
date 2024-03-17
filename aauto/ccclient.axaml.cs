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

public partial class ccclient : Window
{
    
    private List<clientss> cli;
    private string connStr = "server=localhost;database=autose;port=3306;User Id=root;password=кщще";
    private MySqlConnection conn;
    
    public ccclient()
    {
        InitializeComponent();
        string table = "SELECT * FROM clients";
        ShowData(table);
    }
    
    public void ShowData(string sql)
    {
        cli = new List<clientss>();
        conn = new MySqlConnection(connStr);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var cccli = new clientss()
            {
                id = reader.GetInt32("id"),
                surname = reader.GetString("surname"),
                name = reader.GetString("name"),
                lastname = reader.GetString("lastname"),
                phone = reader.GetString("phone"),
                gender_id = reader.GetInt32("gender_id"),
            };
            cli.Add(cccli);
        }

        conn.Close();
        ClientGrid.ItemsSource = cli;
    }
    
    private void Ssearch(object? sender, TextChangedEventArgs e)
    {
        var servv = cli;
        servv = servv.Where(x => x.surname.Contains(Search.Text)).ToList();
        ClientGrid.ItemsSource = servv;
    }
    
    private void Back(object? sender, RoutedEventArgs e)
    {
        var main = new menu();
        main.Show();
        this.Hide();
    } 
    
    private void DeleteData(object? sender, RoutedEventArgs e)
    {
        try
        {
            clientss ssser = ClientGrid.SelectedItem as clientss;
            if (ssser == null)
            {
                return;
            }
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM clients WHERE id = " + ssser.id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            cli.Remove(ssser);
            ShowTable("SELECT id, surname, name, lastname, phone, gender_id FROM clients;");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowTable(string selectIdSurnameNameLastnamePhoneGenderIdFromClients)
    {
        throw new NotImplementedException();
    }

    
}