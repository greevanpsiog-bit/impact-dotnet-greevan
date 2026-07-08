using System;

namespace Week2.Day3
{
    // CUSTOM EVENTARGS
    // -----------------
    // By convention, event data travels inside a class that inherits from
    // EventArgs. This lets you attach whatever extra info subscribers need —
    // here, the exact time the alarm rang.
    public class AlarmEventArgs : EventArgs
    {
        public DateTime AlarmTime { get; }

        public AlarmEventArgs(DateTime alarmTime)
        {
            AlarmTime = alarmTime;
        }
    }

    // EVENT
    // ------
    // An event is a controlled, safer flavor of a multicast delegate.
    // - Outside code can SUBSCRIBE (+=) or UNSUBSCRIBE (-=).
    // - Outside code CANNOT invoke it directly or overwrite the whole list (=).
    //   Only AlarmClock itself can call OnAlarmRing(...) from inside the class.
    // This is what makes events safe for "publish / subscribe" — the publisher
    // controls when it fires, subscribers just react.
    public class AlarmClock
    {
        // The event, built on top of the built-in EventHandler<T> delegate,
        // which has the signature (object sender, TEventArgs e).
        public event EventHandler<AlarmEventArgs>? OnAlarmRing;

        public void RingAlarm()
        {
            Console.WriteLine("[AlarmClock] Ring ring ring!");
            AlarmEventArgs args = new AlarmEventArgs(DateTime.Now);

            // ?.Invoke(...) — only fire if at least one subscriber exists,
            // otherwise this would throw a NullReferenceException.
            OnAlarmRing?.Invoke(this, args);
        }
    }

    // SUBSCRIBERS
    // Any class can react to the event, as long as its method signature
    // matches: (object sender, AlarmEventArgs e)
    public class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;

        public void WakeUp(object? sender, AlarmEventArgs e)
        {
            Console.WriteLine($"[Person: {Name}] Waking up at {e.AlarmTime:T}");
        }
    }

    public class CoffeeMachine
    {
        public void StartBrewing(object? sender, AlarmEventArgs e)
        {
            Console.WriteLine($"[CoffeeMachine] Brewing started at {e.AlarmTime:T}");
        }
    }

    public class Task2_9_Demo
    {
        public static void Run()
        {
            Console.WriteLine("---- Task 2.9: Events ----");

            AlarmClock alarm = new AlarmClock();
            Person person = new Person("Dhasagreevan");
            CoffeeMachine coffeeMachine = new CoffeeMachine();

            // Subscribing — both are just methods that match the event's signature
            alarm.OnAlarmRing += person.WakeUp;
            alarm.OnAlarmRing += coffeeMachine.StartBrewing;

            // One trigger, both subscribers react
            alarm.RingAlarm();

            Console.WriteLine();
        }
    }
}