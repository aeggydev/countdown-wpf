using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using MessageBox = System.Windows.Forms.MessageBox;

namespace countdown;

public class ViewModel : ViewModelBase
{
    private readonly Model _model = new();
    private bool _secondView = false;

    public bool SecondView
    {
        get => _secondView;
        set => SetProperty(ref _secondView, value);
    }
    public Timer GetTimer()
    {
        var timer = new Timer();
        // Calculate total in milliseconds
        timer.Interval = ((Hours.Number * 60 * 60 + Minutes.Number * 60 + Seconds.Number) * 1000) switch
        {
            < 1 => 1,
            var x => x
        };
        MessageBox.Show(timer.Interval.ToString());
        return timer;
    }

    // TODO: Make notify about changed property
    public DoubleUpDown Hours
    {
        get => _model.Hours;
        set => _model.Hours = value;
    }
    public DoubleUpDown Minutes
    {
        get => _model.Minutes;
        set => _model.Minutes = value;
    }    
    public DoubleUpDown Seconds
    {
        get => _model.Seconds;
        set => _model.Seconds = value;
    }

}
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // This is probably useless
    public void OnPropertyChange(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue)) return false;
        
        field = newValue;
        if (propertyName != null) OnPropertyChange(propertyName);
        return true;
    }
}
