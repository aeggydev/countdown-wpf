using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace countdown;

public partial class TimeEntryView : UserControl
{
    public TimeEntryView()
    {
        InitializeComponent();
    }

    private ViewModel? ViewModel => (ViewModel?)DataContext;
    
    private void TextBox_TextChanged(object sender, TextCompositionEventArgs textCompositionEventArgs)
    {
        var box = (TextBox)sender;
        if (Regex.IsMatch(box.Text, "[^0-9]"))
        {
            box.Text = "0";
        }
    }

    private void EnsureSelectedFocus(object sender, RoutedEventArgs e)
    {
        var box = (TextBox)sender;
        box.Focus();
        box.SelectAll();
        e.Handled = true;
        // box.Dispatcher.BeginInvoke(new Action(() => box.SelectAll()));
    }

    private void ButtonStart_OnClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel == null) return;
        
        ViewModel.SetTimer();
        
        ViewModel.Timer.Enabled = true;
        ViewModel.RefreshTimer.Enabled = true;
        ViewModel.Stopwatch.Restart();
        ViewModel.ShowCountdown = true;
    }

    private void SelectionChangedHandler(object sender, RoutedEventArgs e)
    {
        var box = sender as TextBox;
        if (box?.SelectionLength == 0 && !e.Handled)
        {
            box.SelectAll();
        }

        e.Handled = true;
    }
}