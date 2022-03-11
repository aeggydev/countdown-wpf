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
    public int Limit { get; init; }
    public bool SetNumber(int number)
    {
        var asString = number.ToString();
        if (number >= Limit)
        {
            return false;
        }
        if (asString.Length > 2)
        {
            return false;
        }

        if (asString.Length == 1)
        {
            asString = asString.PadLeft(2, '0');
        }

        (FirstDigit, SecondDigit) = (asString[0], asString[1]);
        return true;
    }
    public char FirstDigit { get; set; } = '0';
    public char SecondDigit { get; set; } = '0';
}
public class Model
{
    public DoubleUpDown Hours { get; set; } = new(100);
    public DoubleUpDown Minutes { get; set; } = new(60);
    public DoubleUpDown Seconds { get; set; } = new(60);
}