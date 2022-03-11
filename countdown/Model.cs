namespace countdown;

// TODO: Implement this in a concise way or scrap
public class UpDown
{
    public string value { get; set; } = "2";
}

public class DoubleUpDown
{
    public string FirstDigit { get; set; } = new("0");
    public string SecondDigit { get; set; } = new("0");
}
public class Model
{
    public DoubleUpDown Hours { get; set; } = new();
    public DoubleUpDown Minutes { get; set; } = new();
    public DoubleUpDown Seconds { get; set; } = new();
}