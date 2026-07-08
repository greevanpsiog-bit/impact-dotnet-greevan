// Base notification class with virtual method
public class Notification
{
    public virtual void Send()
    {
        Console.WriteLine("Sending generic notification...");
    }
}

// SMS notification overrides base behavior
public class SmsNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending SMS notification...");
    }
}

// Email notification seals its override - no further overriding allowed
public class EmailNotification : Notification
{
    public sealed override void Send()
    {
        Console.WriteLine("Sending email notification...");
    }
}

// Push notification can still override (not sealed)
public class PushNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending push notification...");
    }
}

// ❌ THIS WILL NOT COMPILE - Uncomment to see the error
/*
public class PriorityEmailNotification : EmailNotification
{
    // Error CS0239: 'PriorityEmailNotification.Send()': 
    // cannot override inherited member 'EmailNotification.Send()' because it is sealed
    public override void Send()
    {
        Console.WriteLine("Sending priority email...");
    }
}
*/