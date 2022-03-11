using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace countdown;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

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
        var box = (TextBox)sender;
        box.Dispatcher.BeginInvoke(new Action(() => box.SelectAll()));
    }

    private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
    {
    }
}