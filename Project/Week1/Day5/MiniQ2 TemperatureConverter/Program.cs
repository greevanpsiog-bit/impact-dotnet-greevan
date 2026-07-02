using BridgeCourse.Week1;

public class Program
{
    public static void Main()
    {
        var converter = new TemperatureConverter();

        // Test 1: From Celsius
        var fromC = converter.Convert(new Celsius(100));
        Console.WriteLine($"Input: 100°C -> C: {fromC.Celsius:F2}, F: {fromC.Fahrenheit:F2}, K: {fromC.Kelvin:F2}");

        // Test 2: From Fahrenheit
        var fromF = converter.Convert(new Fahrenheit(32));
        Console.WriteLine($"Input: 32°F   -> C: {fromF.Celsius:F2}, F: {fromF.Fahrenheit:F2}, K: {fromF.Kelvin:F2}");

        // Test 3: From Kelvin
        var fromK = converter.Convert(new Kelvin(0));
        Console.WriteLine($"Input: 0K     -> C: {fromK.Celsius:F2}, F: {fromK.Fahrenheit:F2}, K: {fromK.Kelvin:F2}");
    }
}