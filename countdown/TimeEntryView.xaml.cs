using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.Forms.MessageBox;

namespace countdown;

public partial class TimeEntryView : UserControl
{
    public TimeEntryView()
    {
        InitializeComponent();
    }

    private ViewModel? ViewModel => (ViewModel?)DataContext;
    
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
        if (ViewModel == null) return;
        
        MessageBox.Show(ViewModel.SecondView.ToString());
        ViewModel.SecondView = true;
        ViewModel.OnPropertyChange("SecondView");
        MessageBox.Show(ViewModel.SecondView.ToString());

        //ViewModel.GetTimer();
    }
}