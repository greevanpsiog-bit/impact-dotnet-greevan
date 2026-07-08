using System;

namespace Week2.Day5.Notifications
{
    // Delegate describing the shape any "sender" method must match.
    public delegate void NotificationSender(string message);

    // Each of these classes exposes a method matching NotificationSender's
    // signature — this is what makes them pluggable into the service below.
    public class EmailSender
    {
        public void Send(string message) => Console.WriteLine($"[Email] Sending: {message}");
    }

    public class SmsSender
    {
        public void Send(string message) => Console.WriteLine($"[SMS] Sending: {message}");
    }

    public class PushSender
    {
        public void Send(string message) => Console.WriteLine($"[Push] Sending: {message}");
    }

    // Event data for when a notification goes out.
    public class NotificationEventArgs : EventArgs
    {
        public string Message { get; }
        public DateTime SentAt { get; }

        public NotificationEventArgs(string message, DateTime sentAt)
        {
            Message = message;
            SentAt = sentAt;
        }
    }

    public class NotificationService
    {
        // The delegate-based sender — decides WHICH channel (Email/SMS/Push)
        // actually delivers the message. This is assigned at construction
        // or changed later, which is the whole point of using a delegate
        // here instead of hardcoding "new EmailSender().Send(...)".
        private readonly NotificationSender sender;

        // The event — fired AFTER a notification is sent, so any number of
        // subscribers (loggers, audit trails, analytics, etc.) can react
        // without NotificationService needing to know they exist.
        public event EventHandler<NotificationEventArgs>? OnNotificationSent;

        public NotificationService(NotificationSender sender)
        {
            this.sender = sender;
        }

        public void Notify(string message)
        {
            sender(message); // actually deliver it via whichever channel was injected

            // Announce "I just sent something" to whoever's listening.
            OnNotificationSent?.Invoke(this, new NotificationEventArgs(message, DateTime.Now));
        }
    }

    // A subscriber whose only job is to log to console when notified.
    public class ConsoleLoggerSubscriber
    {
        public void LogNotification(object? sender, NotificationEventArgs e)
        {
            Console.WriteLine($"  [Log] Notification sent at {e.SentAt:T}: \"{e.Message}\"");
        }
    }

    public class Task_MiniQ5_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Mini Q5: Notification Engine ----");

            EmailSender emailSender = new EmailSender();
            SmsSender smsSender = new SmsSender();
            PushSender pushSender = new PushSender();

            ConsoleLoggerSubscriber logger = new ConsoleLoggerSubscriber();

            // Three independent services, each wired to a different delivery channel.
            NotificationService emailService = new NotificationService(emailSender.Send);
            NotificationService smsService = new NotificationService(smsSender.Send);
            NotificationService pushService = new NotificationService(pushSender.Send);

            // Every service's OnNotificationSent event uses the SAME logger.
            emailService.OnNotificationSent += logger.LogNotification;
            smsService.OnNotificationSent += logger.LogNotification;
            pushService.OnNotificationSent += logger.LogNotification;

            emailService.Notify("Your order has shipped!");
            smsService.Notify("OTP: 4821");
            pushService.Notify("You have a new message");

            Console.WriteLine();
        }
    }
}