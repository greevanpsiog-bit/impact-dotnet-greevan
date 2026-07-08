# WEEK 2 — OOP, Delegates, Events, Generics & LINQ

**Modules 3–5 · 15 hrs**

### 🎯 Objective
Model a domain with proper OOP and query collections fluently — the two skills the Web API leans on hardest.

### 📚 Syllabus Covered
* **Module 3:** Encapsulation, inheritance, overriding, abstract classes, interfaces, polymorphism, method hiding (`new`), operator overloading.
* **Module 4:** Delegates, events, lambdas, `Action`/`Func`/`Predicate`.
* **Module 5:** Generics, `IEnumerable`/`yield`, LINQ (query & method syntax), extension methods, anonymous types.

### 💡 Core Concepts
The four OOP pillars in code, callback/pub-sub via delegates and events, and type-safe reusable collections with LINQ querying.

> **Fresher catch-up note:** *This week runs at the experienced-cohort pace. Freshers should prioritise the coding tasks over reading, repeat the LINQ tasks in spare evening time, and lean on pairing during the OOP days.*

---

## 🏛️ Day 1 — Encapsulation, Inheritance, Overriding

| 📝 Learning Notes & "Done When" Criteria | 📸 Evidence |
|---|---|
| **Task 2.1: BankAccount Encapsulation**<br>• Private balance; Deposit/Withdraw/GetBalance with validation.<br>• Private history list + PrintHistory().<br>• **Done when:** An overdraw is rejected and the history logs every operation. | **Task 2.1**<br>![Task 2.1](Assets/Screenshots/Week2/2026-07-08-14-09-10.png) |
| **Task 2.2: Inheritance & Constructor Chaining**<br>• `Vehicle` → `Car`/`Bike` overrides.<br>• `ElectricCar : Car` with `: base(...)` chain.<br>• **Done when:** Constructor chain runs top-to-bottom; each override prints its own info. | **Task 2.2**<br>![Task 2.2](Assets/Screenshots/Week2/2026-07-08-14-13-04.png) |
| **Task 2.3: Virtual, Override & Sealed**<br>• `Notification.Send()` virtual → Email/Sms/Push overrides.<br>• `EmailNotification.Send()` marked `sealed`.<br>• **Done when:** The sealed-override compile error is captured. | *(Code committed to repo)* |

---

## 🧩 Day 2 — Abstract, Interfaces, Polymorphism, Hiding, Operators

| 📝 Learning Notes & "Done When" Criteria | 📸 Evidence |
|---|---|
| **Task 2.4: Abstract Classes**<br>• Abstract `Shape` with `CalculateArea()`.<br>• `Circle`/`Rectangle` implementations.<br>• **Done when:** Both shapes compute area and the `new Shape()` instantiation error is shown. | **Task 2.4**<br>![Task 2.4](Assets/Screenshots/Week2/2026-07-08-14-22-51.png) |
| **Task 2.5: Multiple Interfaces**<br>• `IShape` + `IDrawable` implemented in one class.<br>• **Done when:** One class satisfies both interfaces; interface-vs-abstract comment block added. | **Task 2.5**<br>![Task 2.5](Assets/Screenshots/Week2/2026-07-08-14-27-29.png) |
| **Task 2.6: Polymorphism & Method Hiding**<br>• Overloaded `Calculator.Add()`.<br>• `List<Shape>` loop calling correct `CalculateArea()`.<br>• `Logger.Log()` vs `FileLogger.Log()` using `new`.<br>• **Done when:** Runtime polymorphism picks derived area; `new` vs `override` behavior documented. | **Task 2.6**<br>![Task 2.6](Assets/Screenshots/Week2/2026-07-08-14-32-27.png) |
| **Task 2.7: Operator Overloading**<br>• `Money` struct: overload `+`, `==`, `!=`, `>`, `<`.<br>• **Done when:** Mismatched-currency addition throws exception; comparisons return correct results. | **Task 2.7**<br>![Task 2.7](Assets/Screenshots/Week2/2026-07-08-14-33-28.png) |

---

## 🔔 Day 3 — Delegates & Events

| 📝 Learning Notes & "Done When" Criteria | 📸 Evidence |
|---|---|
| **Task 2.8: Delegates & Multicast**<br>• `MathOperation` delegate with Add/Sub/Mult/Div.<br>• Multicast invocation + `Func<double,double,double>` rewrite.<br>• **Done when:** Multicast runs both methods; Func version matches output. | **Task 2.8**<br>![Task 2.8](Assets/Screenshots/Week2/2026-07-08-14-33-54.png) |
| **Task 2.9: Events & Custom EventArgs**<br>• `AlarmClock.OnAlarmRing` event.<br>• Subscribers: `Person` and `CoffeeMachine`.<br>• Custom `AlarmEventArgs` with `DateTime`.<br>• **Done when:** Triggering alarm notifies both subscribers with time. | **Task 2.9**<br>![Task 2.9](Assets/Screenshots/Week2/2026-07-08-14-38-49.png) |
| **Task 2.10: Action, Func, Predicate**<br>• `ProcessList` method: Filter (Predicate) → Transform (Func) → Output (Action).<br>• **Done when:** Filtering evens → squaring → printing produces expected sequence. | **Task 2.10**<br>![Task 2.10](Assets/Screenshots/Week2/2026-07-08-14-39-19.png) |

---

## 📦 Day 4 — Generics, yield, LINQ

| 📝 Learning Notes & "Done When" Criteria | 📸 Evidence |
|---|---|
| **Task 2.11: Generic Repository**<br>• `Repository<T>` with Add/Update/Delete/GetAll.<br>• Tested with `Student` and `Product`.<br>• Constraint `where T : class, new()` explained.<br>• **Done when:** Same repo works for two types; constraint logic explained. | **Task 2.11**<br>![Task 2.11](Assets/Screenshots/Week2/2026-07-08-14-39-56.png) |
| **Task 2.12: IEnumerable & Yield**<br>• `GetEvenNumbers` with `yield return`.<br>• `BookCollection : IEnumerable<Book>` yielding alphabetically.<br>• **Done when:** Iterator is consumed lazily in a `foreach`. | **Task 2.12**<br>![Task 2.12](Assets/Screenshots/Week2/2026-07-08-14-48-50.png) |
| **Task 2.13: LINQ Queries (Dual Syntax)**<br>• Employee list (10+ rows): Filter, Order, GroupBy, Project.<br>• Written in both Query and Method syntax.<br>• **Done when:** Every query is written twice and returns identical results. | **Task 2.13**<br>![Task 2.13](Assets/Screenshots/Week2/2026-07-08-14-49-15.png) |

---

## 🚀 Day 5 — Extensions, Anonymous Types + Mini-Projects

| 📝 Learning Notes & "Done When" Criteria | 📸 Evidence |
|---|---|
| **Task 2.14: Extension Methods & Anonymous Types**<br>• Extensions: `ToTitleCase()`, `IsNullOrEmpty()`, `ToWords()`.<br>• Project Employee to anonymous type.<br>• **Done when:** All three extensions pass examples; anonymous type limitation noted. | **Task 2.14**<br>![Task 2.14](Assets/Screenshots/Week2/2026-07-08-14-49-39.png) |
| **Mini Q4: Employee Payroll**<br>• Abstract `Employee.CalculateSalary()`.<br>• FullTime/PartTime/Contract implementations.<br>• `ITaxable` on FullTime only.<br>• LINQ GroupBy department.<br>• **Done when:** Total payroll is correct; per-department grouping prints. | **Mini Q4**<br>![Q4](Assets/Screenshots/Week2/Q4/q4.png) |
| **Mini Q5: Notification Engine**<br>• Delegate-based sender (Email/Sms/Push).<br>• `NotificationService.OnNotificationSent` event.<br>• **Done when:** Sending a notification fires the event and logs it. | **Mini Q5**<br>![Q5](Assets/Screenshots/Week2/Q5/q5.png) |
| **Mini Q6: Library Management (LINQ)**<br>• 15+ Books: Available by author, Group by genre, Oldest book, Post-2010 sorted.<br>• **Done when:** All four queries return correct results. | **Mini Q6**<br>![Q6](Assets/Screenshots/Week2/Q6/q6.png) |

---

## 📦 Weekly Deliverable & Submission Checklist

* [x] **Week02 Folder:** All OOP exercises + three mini-projects are runnable and committed via ≥1 PR.
* [x] **Learning Document:** Created (.docx/.md) covering Learnings (Modules 3, 4, 5) and Doables (Tasks 2.1 - 2.14 + Minis). Embedded screenshots of key tasks.
* [x] **Git Submission:** Repo link and merged PR URL for Week 02 work.
* [x] **Assignments:** Mini-projects (Q4, Q5, Q6) committed and listed.

---

## 🎓 Lessons Learnt
*By the end of this week, I can:*
1. Enforce invariants with encapsulation and build multi-level inheritance with constructor chaining.
2. Control overriding with `virtual`/`override`/`sealed`, and explain why an abstract class can't be instantiated.
3. Implement multiple interfaces on one class and watch runtime polymorphism pick the right method.
4. Overload operators, and explain method hiding (`new`) versus `override`.
5. Use delegates, multicast, events with custom `EventArgs`, and `Action`/`Func`/`Predicate`.
6. Write reusable generics, lazy iterators with `yield`, and LINQ queries in both query and method syntax.
7. Add extension methods and use anonymous types.
8. **Shipped:** Employee Payroll, Notification Engine, and Library Management (LINQ).