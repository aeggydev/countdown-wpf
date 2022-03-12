using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace countdown;

public class ViewModel : ViewModelBase
{
    private readonly Model _model = new();
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

    public bool ShowCountdown
    {
        get => _model.ShowCountdown;
        set => SetProperty(ref _model.ShowCountdown, value);
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
    
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
