using System;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace countdown;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ViewModel ViewModel { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        ViewModel = (DataContext as ViewModel)!;
        var timer = new System.Threading.Timer(_ => ViewModel.OnPropertyChange(nameof(ViewModel.SecondView)),
            null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
    }

    private Timer Timer { get; set; } = new Timer();
    
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var box = (TextBox)sender;
        if (Regex.IsMatch(box.Text, "[^0-9]"))
        {
            box.Text = "0";
            TextBox_GotFocus(sender, null);
        }
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        ViewModel.OnPropertyChange(nameof(ViewModel.SecondView));
        var box = (TextBox)sender;
        box.Dispatcher.BeginInvoke(new Action(() => box.SelectAll()));
    }

    private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
    {
        ViewModel.GetTimer();
    }
}