namespace BridgeCourse.Week1;

// Record automatically provides value-based equality and a 'with' expression for non-destructive mutation
public record Address(string Street, string City, string Pincode);