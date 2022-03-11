using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace countdown;

public class ViewModel : ViewModelBase
{
    private readonly Model _model = new();


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
    protected void OnPropertyChange(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue)) return false;
        
        field = newValue;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}
