using System;

namespace BridgeCourse.Week1;

// 1. Define Records for each Unit (encapsulates "value + unit")
public record Celsius(double Value);
public record Fahrenheit(double Value);
public record Kelvin(double Value);

// 2. Define a Record for the output to keep it clean
public record TemperatureResult(double Celsius, double Fahrenheit, double Kelvin);

public class TemperatureConverter
{
    // Overload 1: Input is Celsius
    public TemperatureResult Convert(Celsius c)
    {
        double f = (c.Value * 9.0 / 5.0) + 32;
        double k = c.Value + 273.15;
        return new TemperatureResult(c.Value, f, k);
    }

    // Overload 2: Input is Fahrenheit
    public TemperatureResult Convert(Fahrenheit f)
    {
        double c = (f.Value - 32) * 5.0 / 9.0;
        double k = c + 273.15;
        return new TemperatureResult(c, f.Value, k);
    }

    // Overload 3: Input is Kelvin
    public TemperatureResult Convert(Kelvin k)
    {
        double c = k.Value - 273.15;
        double f = (c * 9.0 / 5.0) + 32;
        return new TemperatureResult(c, f, k.Value);
    }
}