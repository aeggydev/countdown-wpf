using System;
using System.Windows;

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

    private ViewModel? ViewModel => DataContext as ViewModel;
}