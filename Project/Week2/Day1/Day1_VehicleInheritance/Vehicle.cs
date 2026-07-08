// Base class defining common vehicle properties
public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    // Base constructor - always called first in the chain
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
        Console.WriteLine($"[Vehicle] Initialized: {Year} {Make} {Model}");
    }

    // Virtual method allows derived classes to override behavior
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Vehicle: {Year} {Make} {Model}");
    }
}

// First level of inheritance - adds car-specific properties
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    // Constructor chains to base Vehicle constructor using : base(...)
    public Car(string make, string model, int year, int numberOfDoors) 
        : base(make, model, year)
    {
        NumberOfDoors = numberOfDoors;
        Console.WriteLine($"[Car] Doors: {NumberOfDoors}");
    }

    // Override extends base behavior while preserving it
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Call base implementation first
        Console.WriteLine($"Car: {NumberOfDoors} doors");
    }
}

// Sibling class showing different inheritance path
public class Bike : Vehicle
{
    public bool HasSidecar { get; set; }

    public Bike(string make, string model, int year, bool hasSidecar) 
        : base(make, model, year)
    {
        HasSidecar = hasSidecar;
        Console.WriteLine($"[Bike] Sidecar: {HasSidecar}");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Bike: Has Sidecar = {HasSidecar}");
    }
}

// Second level of inheritance - ElectricCar inherits from Car (not Vehicle directly)
public class ElectricCar : Car
{
    public double BatteryCapacity { get; set; }

    // Chains to Car constructor, which then chains to Vehicle
    public ElectricCar(string make, string model, int year, int doors, double batteryCapacity) 
        : base(make, model, year, doors)
    {
        BatteryCapacity = batteryCapacity;
        Console.WriteLine($"[ElectricCar] Battery: {BatteryCapacity} kWh");
    }

    // Further extends the display info with electric-specific details
    public override void DisplayInfo()
    {
        base.DisplayInfo(); // Calls Car.DisplayInfo(), which calls Vehicle.DisplayInfo()
        Console.WriteLine($"ElectricCar: Battery Capacity = {BatteryCapacity} kWh");
    }
}