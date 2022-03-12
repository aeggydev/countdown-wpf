using System;
using System.Timers;

namespace countdown;

// TODO: Implement this in a concise way or scrap
public class UpDown
{
    public string value { get; set; } = "2";
}

public class DoubleUpDown
{
    public DoubleUpDown(int limit)
    {
        Limit = limit;
    }
    public int Limit { get; set; }

    public int Number
    {
        get => Int32.Parse(FirstDigit.ToString()+SecondDigit);
        set
        {
            var asString = value.ToString();
            if (value >= Limit)
            {
                // TODO: Handle overflow
                Number = 0;
                return;
            }

            asString = asString.Length switch
            {
                1 => asString.PadLeft(2, '0'),
                2 => asString,
                _ => throw new ArgumentOutOfRangeException($"{value} doesn't fit into limit of bigger than 0 and smaller than {Limit}")
            };

            (FirstDigit, SecondDigit) = (asString[0], asString[1]);
        }
    }
    public char FirstDigit { get; set; } = '0';
    public char SecondDigit { get; set; } = '0';
}
public class Model
{
    public bool ShowCountdown = false;
    public Timer? Timer = null;
    public DoubleUpDown Hours { get; set; } = new(100);
    public DoubleUpDown Minutes { get; set; } = new(60);
    public DoubleUpDown Seconds { get; set; } = new(60);
}