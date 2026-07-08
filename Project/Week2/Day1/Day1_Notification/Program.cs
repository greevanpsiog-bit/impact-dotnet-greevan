Console.WriteLine("=== Testing Sealed Override ===\n");

// All notifications work normally
var sms = new SmsNotification();
sms.Send(); // Output: Sending SMS notification...

var email = new EmailNotification();
email.Send(); // Output: Sending email notification...

var push = new PushNotification();
push.Send(); // Output: Sending push notification...

Console.WriteLine("\n--- Attempting to override sealed method ---");
Console.WriteLine("Uncomment PriorityEmailNotification class to see compile error CS0239");