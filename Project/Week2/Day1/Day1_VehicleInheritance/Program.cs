Console.WriteLine("=== Testing Vehicle Inheritance ===\n");

// Create an ElectricCar - watch constructor chain execute top-to-bottom
var tesla = new ElectricCar("Tesla", "Model 3", 2024, 4, 82);
Console.WriteLine();

// DisplayInfo should show all levels of information
tesla.DisplayInfo();
Console.WriteLine("\n---\n");

// Test Car separately
var honda = new Car("Honda", "Civic", 2023, 4);
honda.DisplayInfo();
Console.WriteLine("\n---\n");

// Test Bike
var harley = new Bike("Harley-Davidson", "Street Glide", 2024, false);
harley.DisplayInfo();