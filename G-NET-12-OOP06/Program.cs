using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Transactions;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace G_NET_12_OOP06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region G-NET-12-OOP06 assignment

            #region part 1 : q 1

            //1.Abstraction in OOP

            //Abstraction means showing only the essential features of an object while hiding the complex internal details.
            //In other words, the user interacts with what the object does, not how it does it.

            //In programming, abstraction is often implemented using:

            //-Abstract classes
            //-Interfaces

            //These define methods that must exist, but the internal implementation can vary.

            //2.Difference Between Abstraction and Encapsulation

            //|     Aspect     |        Abstraction            |              Encapsulation                    |
            //| -------------- | ----------------------------- | --------------------------------------------- |
            //| Purpose        | Hide complex implementation   | Protect and control access to data            |
            //| Focus          | What an object does           | How data is protected                         |
            //| Implementation | Abstract classes / Interfaces | Access modifiers(private, public, protected)  |
            //| Main Idea      | Simplify usage                | Secure data                                   |

            //4.Real - World Example Showing the Difference

            //Example: ATM Machine

            //Abstraction
            //When you withdraw money from an ATM:

            //.You insert card
            //.Enter PIN
            //.Select withdraw

            //You do not see the internal banking processes like:

            //.account verification
            //.transaction logging
            //.database updates

            //This is abstraction -> hiding complex processes.

            //Encapsulation            
            //Inside the bank system:

            //.Your account balance is private            
            //.It cannot be changed directly

            //You must use methods like:

            //withdraw(amount)           
            //deposit(amount)

            //The system controls how the balance changes.

            //This is encapsulation -> protecting the data.

            #endregion

            #region part 1 : q 2

            //Difference Between an Abstract Class and an Interface

            //Both abstract classes and interfaces are used in Object-Oriented Programming to achieve abstraction,
            //but they are used in different ways.

            //|     Feature      |                Abstract Class                    |                     Interface                        |
            //| ---------------- | ------------------------------------------------ | ---------------------------------------------------- |
            //| Methods          | Can have both abstract and concrete methods      | Usually contains only abstract methods               |
            //| Variables        | Can have instance variables(fields)              | Usually contains constants(public static final)      |
            //| Constructors     | Can have constructors                            | Cannot have constructors                             |
            //| Inheritance      | A class can extend only one abstract class       | A class can implement multiple interfaces            |
            //| Access Modifiers | Methods can be private, protected, or public     | Methods are usually public                           |
            //| Implementation   | Can provide partial implementation               | Usually provides only method declarations            |

            //3.When to Use Each

            //Use an Abstract Class When:

            //-Classes share common attributes or behavior.
            //-You want to reuse code.             
            //-You need constructors or instance variable

            //Use an Interface When:

            //-Different classes should follow the same behavior but are not closely related.           
            //-You need multiple inheritance.            
            //-You want to define a contract.
            #endregion

            #region part 1 : q 3

            //a) Can you write: Appliance a = new Appliance("LG"); ? Why or why not?

            //No, you cannot do this.

            //Reason:
            //Appliance is declared as an abstract class:

            //public abstract class Appliance

            //Abstract classes cannot be instantiated directly.They are meant to act as base classes for other classes.

            //They may contain abstract methods that must be implemented by derived classes, so the class itself is incomplete.

            //b) What is the difference between the three methods:
            //PowerConsumption(), Status(), and Label()?
            //Why did the designer make each one abstract, virtual, or concrete?

            //1-PowerConsumption()

            //public abstract double PowerConsumption();

            //Type: Abstract Method

            //Meaning:

            //-Has no implementation in the base class.

            //-Must be overridden in every derived class.

            //Why?
            //Because different appliances consume different amounts of power.

            //2-Status()

            //public virtual string Status() => "Standby";

            //Type: Virtual Method

            //Meaning:

            //-Has a default implementation.
            //-Subclasses may override it, but they don't have to.

            //Why?
            //Most appliances may have a default state "Standby", but some appliances may want a custom status.

            //3-Label()

            //public string Label() => $"{Brand} - {PowerConsumption()}W";

            //Type: Concrete Method

            //Meaning:

            //-Fully implemented in the base class.           
            //-Subclasses cannot override it(unless marked virtual).

            //Why?
            //Because all appliances should display their label in the same format:

            //Brand - PowerConsumptionW

            //c) If you call Status() on a Toaster object, what will it return? Why ?

            //Toaster t = new Toaster("Philips");
            //Console.WriteLine(t.Status());

            //✔ Output:

            //Standby

            //Reason:

            //Toaster does not override the Status() method:

            //public class Toaster : Appliance
            //        {
            //            public Toaster(string brand) : base(brand) { }
            //            public override double PowerConsumption() => 800;
            //        }

            //        So it automatically uses the default implementation from the base class:

            //public virtual string Status() => "Standby";

            #endregion

            #region part 1 : q 4

            //a) What is a partial class? Why split Calculator into two files?

            //A partial class is a class whose definition is divided into multiple files,
            //but the compiler combines them into one class during compilation.\

            //Why developers use partial classes?

            //1.Better code organization – different features can be placed in separate files.

            //2.Team development – multiple developers can work on the same class without conflicts.

            //3.Separation of concerns – main logic in one file, logging or extra functionality in another.

            //4.Auto-generated code – tools can generate one part while developers edit another safely.

            //b) What is a partial method?
            //What happens if the OnCalculated() implementation in Calculator.Logging.cs is deleted — will the code still compile? Why?

            //A partial method is a method whose declaration appears in one part of a partial class and its implementation can appear in another part.

            //Example declaration:

            //partial void OnCalculated(double result);

            //        Implementation:

            //partial void OnCalculated(double result)
            //        {
            //            Console.WriteLine($"Log: result = {result}");
            //        }

            //What happens if the implementation is deleted?

            // Yes, the code will still compile.

            //Reason:

            //If a partial method has no implementation, the compiler:

            //Removes the method call

            //Removes the method declaration

            //c) What is an extension method? What are the three rules for writing one?

            //n extension method allows you to add new methods to an existing class without modifying the original class.

            //Example in the code:

            //public static string ToCurrency(this double value)

            //This makes ToCurrency() behave like a method of the double type.

            //Example usage:

            //double price = 10.5;
            //        price.ToCurrency();
            //Three rules for writing an extension method

            //1️ The method must be inside a static class

            //public static class DoubleExtensions

            //2️ The method itself must be static

            //public static string ToCurrency(...)

            //3️ The first parameter must use the this keyword to specify the type being extended

            //this double value

            //d) What will the following code print?

            //Calculator calc = new Calculator();
            //double result = calc.Add(19.5, 0.5);
            //Console.WriteLine(result.ToCurrency());

            //✔ Output:
            //Log: result = 20
            //$20.00

            #endregion

            #region part 2 : Practical (Extending the Movie Ticket Booking System)

            //Cinema cinema = new Cinema();

            //cinema.OpenCinema();

            //// Ticket t = new Ticket("Test", 100);
            //// ERROR: Cannot create instance of abstract class

            //Ticket t1 = new StandardTicket(1, "Inception", 80, "A5");
            //Ticket t2 = new VIPTicket(2, "Avengers", 200, true, 50);
            //Ticket t3 = new IMAXTicket(3, "Dune", 130, true);

            //t1.Book();
            //t2.Book();
            //t3.Book();

            //cinema.AddTicket(t1);
            //cinema.AddTicket(t2);
            //cinema.AddTicket(t3);

            //cinema.PrintAllTickets();

            //Console.WriteLine("--- Polymorphism: Final Price per Ticket ---");

            //Ticket[] tickets = { t1, t2, t3 };

            //foreach (var t in tickets)
            //{
            //    Console.WriteLine($"{t.GetType().Name} => Final Price: {t.CalculateFinalPrice():F2}");
            //}

            //Console.WriteLine();

            //Console.WriteLine("--- Extension Method: Receipt ---");
            //Console.WriteLine(t2.GenerateReceipt());

            //Console.WriteLine();

            //Console.WriteLine("--- Extension Method: Total Revenue ---");
            //Console.WriteLine($"Total Revenue: {tickets.TotalRevenue():F2}");

            //cinema.CloseCinema();

            #endregion

            #endregion

        }
    }
}
