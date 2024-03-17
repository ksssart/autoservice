using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace aauto;

public partial class menu : Window
{
    private void Service(object? sender, RoutedEventArgs e)
    {
        var mat = new admin();
        mat.Show();
        this.Hide();
    }
    
    private void back(object? sender, RoutedEventArgs e)
    {
        var mat = new MainWindow();
        mat.Show();
        this.Hide();
    }
    
    private void order (object? sender, RoutedEventArgs e)
    {
        var or = new ordersForm();
        or.Show();
        this.Hide();
    }
    
    private void Client(object? sender, RoutedEventArgs e)
    {
        var cl = new ccclient();
        cl.Show();
        this.Hide();
    }
    
    public menu()
    {
        InitializeComponent();
    }
}