/* 

================================================================================
NOTE: Built-in exception types
================================================================================
// These are standard exception types provided by .NET. They are commonly used to represent
// typical error scenarios and can also serve as base classes when creating your own
// custom exceptions.

// Common built-in exception types include:
// - ArgumentException / ArgumentNullException: Thrown when a method receives an invalid or null argument.
// - InvalidOperationException: Thrown when an operation is not valid due to the object's current state.
// - NotSupportedException: Thrown when an invoked method is not supported.
// - IOException: Thrown when an I/O operation (like file access) fails.
// - FormatException: Thrown when a string is not in the expected format.

// You can use these exceptions directly in your code, or derive your own custom exceptions
// from them when you need more specific error handling logic.

// Create an exception object
ArgumentException invalidArgumentException = new ArgumentException();

// Configure and throw customized exception

// The process for throwing an exception object involves creating an instance of an exception-derived 
// class, optionally configuring properties of the exception, and then throwing the object by using the throw keyword.

ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
throw invalidArgumentException;

// Exception object can also be created and thrown in a single line
throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");

// When to throw an exception?
string[][] userEnteredValues = new string[][]
{
        new string[] { "1", "two", "3"},
        new string[] { "0", "1", "2"}
};

foreach (string[] userEntries in userEnteredValues)
{
    try
    {
        BusinessProcess1(userEntries);
    }
    catch (Exception ex)
    {
        if (ex.StackTrace.Contains("BusinessProcess1") && (ex is FormatException))
        {
            Console.WriteLine(ex.Message);
        }
    }
}

static void BusinessProcess1(string[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        try
        {
            valueEntered = int.Parse(userValue);

            // completes required calculations based on userValue
            // ...
        }
        catch (FormatException)
        {
            FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
            throw invalidFormatException;
        }
    }
}

// Re-throwing exceptions

// Working structure 1
catch (Exception ex)
{
    // handle or partially handle the exception
    // ...

    // re-throw the original exception object for further handling down the call stack
    throw;
}

// Working structure 2
catch (Exception ex)
{
    // handle or partially handle the exception
    // ...

    // create a new exception object that wraps the original exception
    throw new ApplicationException("An error occurred", ex);
}

// Code sample
try
{
    OperatingProcedure1();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Exiting application.");
}

static void OperatingProcedure1()
{
    string[][] userEnteredValues = new string[][]
    {
        new string[] { "1", "two", "3"},
        new string[] { "0", "1", "2"}
    };

    foreach(string[] userEntries in userEnteredValues)
    {
        try
        {
            BusinessProcess1(userEntries);
        }
        catch (Exception ex)
        {
            if (ex.StackTrace.Contains("BusinessProcess1"))
            {
                if (ex is FormatException)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Corrective action taken in OperatingProcedure1");
                }
                else if (ex is DivideByZeroException)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Partial correction in OperatingProcedure1 - further action required");

                    // re-throw the original exception
                    throw;
                }
                else
                {
                    // create a new exception object that wraps the original exception
                    throw new ApplicationException("An error occurred - ", ex);
                }
            }
        }

    }
}

static void BusinessProcess1(string[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        try
        {
            valueEntered = int.Parse(userValue);

            checked
            {
                int calculatedValue = 4 / valueEntered;
            }
        }
        catch (FormatException)
        {
            FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
            throw invalidFormatException;
        }
        catch (DivideByZeroException)
        {
            DivideByZeroException unexpectedDivideByZeroException = new DivideByZeroException("DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero");
            throw unexpectedDivideByZeroException;

        }
    }
}

// Output:
// FormatException: User input values in 'BusinessProcess1' must be valid integers
// Corrective action taken in OperatingProcedure1
// DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero
// Partial correction in OperatingProcedure1 - further action required
// DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero
// Exiting application.

================================================================================
NOTE: try-catch-finally block programs
================================================================================
// Code sample 1: simple try-catch block
double float1 = 3000.0;
double float2 = 0.0;
int number1 = 3000;
int number2 = 0;

try
{
    Console.WriteLine(float1 / float2); // Output: Infinity (Because dividing by zero in floating-point arithmetic results in Infinity)
    Console.WriteLine(number1 / number2); // Output: System.DivideByZeroException (Because dividing by zero in integer arithmetic throws an exception)
}
catch
{
    Console.WriteLine("An exception has been caught"); // Output: An exception has been caught (This will be printed because the second division throws an exception)
}

Console.WriteLine("Exit program"); // Output: Exit program

// Code sample 2: exception is caught in the main method
try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    WriteMessage();
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;

    Console.WriteLine(float1 / float2);
    Console.WriteLine(number1 / number2);
}

// Code sample 3: exception is caught in the Process1 method and main method's catch block is ignored
try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    try
    {
        WriteMessage();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception caught in Process1: {ex.Message}");
    }
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;
    byte smallNumber;

    Console.WriteLine(float1 / float2);
    Console.WriteLine(number1 / number2);
}

// Code sample 4: catching specific exception, DivideByZeroException is derived class, which is inherited from System.Exception base class
try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    try
    {
        WriteMessage();
    }
    catch (DivideByZeroException ex) // Catching specific exception
    {
        Console.WriteLine($"Exception caught in Process1: {ex.Message}");
    }
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;
    byte smallNumber;

    Console.WriteLine(float1 / float2);
    Console.WriteLine(number1 / number2);
}

// Code sample 5: catching multiple exceptions, make sure to have the try and catch block close to where the exception occurs
try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    try
    {
        WriteMessage();
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Exception caught in Process1: {ex.Message}");
    }
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;
    byte smallNumber;

    try
    {
        Console.WriteLine(float1 / float2);
        Console.WriteLine(number1 / number2);
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Exception caught in WriteMessage: {ex.Message}");
    }
    checked
    {
        try
        {
            smallNumber = (byte)number1;
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Exception caught in WriteMessage: {ex.Message}");
        }
    }
}

// Output:
// ∞
// Exception caught in WriteMessage: Attempted to divide by zero.
// Exception caught in WriteMessage: Arithmetic operation resulted in an overflow.
// Exit program

// Code sample 6: catch seperate exception types in a code block
// inputValues is used to store numeric values entered by a user
string[] inputValues = new string[] { "three", "9999999999", "0", "2" };

foreach (string inputValue in inputValues)
{
    int numValue = 0;
    try
    {
        numValue = int.Parse(inputValue);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid readResult. Please enter a valid number.");
    }
    catch (OverflowException)
    {
        Console.WriteLine("The number you entered is too large or too small.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Output:
// Invalid readResult. Please enter a valid number.
// The number you entered is too large or too small.

================================================================================
NOTE: Code verification
================================================================================
// Code verification is a process of checking the code for correctness, and it
// includes software testing, debugging and exception handling

// - Software testing is a process of executing the code to find errors.
//   It is done by running the code with different inputs and checking the output
//   against the expected output. It is done using unit tests, integration tests,
//   system tests, and acceptance tests.

// - Debugging is a process of finding and fixing the errors in the code.
//   It is done by using a debugger, which is a tool that allows you to step through
//   the code line by line, inspect variables, and see the flow of execution.
//   It is done using breakpoints, watch windows, and call stacks.
//   Debugging is an important part of the software development process, as it helps
//   to identify and fix bugs in the code. It is done using various techniques, such as
//   print debugging, interactive debugging, and remote debugging.

// - Exception handling is a process of handling the errors that occur during
//   the execution of the code. It is a way to handle errors gracefully and
//   prevent the program from crashing. It is done using try-catch-finally blocks.

// try-catch-finally block
try
{   
   // try code block - code that may generate an exception
}
catch
{   
   // catch code block - code to handle an exception
}
finally
{   
   // finally code block - code to clean up resources
}

// Control flow of try-catch-finally block
try
{
    // Step 1: code execution begins
    try
    {
        // Step 2: an exception occurs here
    }
    finally
    {
        // Step 4: the system executes the finally code block associated with the try statement where the exception occurred
    }

}
catch // Step 3: the system finds a catch clause that can handle the exception
{
    // Step 5: the system transfers control to the first line of the catch code block
}

// My analogy

// Code sample 1: exception caught by main method
void Main()
{
    try
    {
        CallMethod1(); // Exception handled locally, does not propagate
        CallMethod2(); // Exception not caught locally, propagates to this method's catch
    }
    catch
    {
        // This executes *after* CallMethod2's finally block runs
        // Because CallMethod2 did not catch the exception
    }
}

void CallMethod1()
{
    try
    {
        // Exception occurs
    }
    catch
    {
        // Exception is handled here
        // So it doesn't propagate to Main's catch block
    }
}

void CallMethod2()
{
    try
    {
        // Exception occurs
    }
    finally
    {
        // Always runs even if an exception occurs
        // Control goes to Main's catch after this block if not handled here
    }
}

// Code sample 2: what happens without a catch?
void Main()
{
    try
    {
        CallMethod1(); // Executes normally
        CallMethod2(); // Exception occurs here
    }
    // No catch here!
}

void CallMethod1()
{
    try
    {
        // No exception here
    }
    catch
    {
        // Would only handle exceptions from within this method
    }
}

void CallMethod2()
{
    try
    {
        // Exception occurs
    }
    finally
    {
        // Runs before the program crashes or control moves up
    }
}

================================================================================
NOTE: Create C# methods with return values
================================================================================
double total = 0;
double minimumSpend = 30.00;

double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

for (int i = 0; i < items.Length; i++)
{
    total += GetDiscountedPrice(i);
}

total -= TotalMeetsMinimum() ? 5.00 : 0.00;

Console.WriteLine($"Total: ${FormatDecimal(total)}");

double GetDiscountedPrice(int itemIndex)
{
    return items[itemIndex] * (1 - discounts[itemIndex]);
}

bool TotalMeetsMinimum()
{
    return total >= minimumSpend;
}

string FormatDecimal(double input)
{
    return input.ToString().Substring(0, 5);
}

================================================================================
NOTE: Create C# methods with parameters
================================================================================
// When creating methods, you'll often want to provide some information for the 
// method to use. Information consumed by a method is called a parameter. You can 
// supply as many parameters as needed to accomplish its task, or none at all.

// The terms 'parameter' and 'argument' are often used interchangeably. However, 
// 'parameter' refers to the variable in the method signature. The 'argument' is 
// the value passed when the method is called.

// Code sample 1
CountTo(5);

void CountTo(int max) 
{
    for (int i = 0; i < max; i++)
    {
        Console.Write($"{i}, ");
    }
}

// Code sample 2
int[] schedule = { 800, 1200, 1600, 2000 };

DisplayAdjustedTimes(schedule, 6, -6);

void DisplayAdjustedTimes(int[] times, int currentGMT, int newGMT)
{
    int diff = 0;
    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
        Console.WriteLine("Invalid GMT");

    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));

    else
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));

    for (int i = 0; i < times.Length; i++)
    {
        int newTime = ((times[i] + diff)) % 2400;
        Console.WriteLine($"{times[i]} -> {newTime}");
    }
}

// Method scope

// Code sample 1
string[] students = { "Jenna", "Ayesha", "Carlos", "Viktor" };

DisplayStudents(students);
DisplayStudents(new string[] { "Robert", "Vanya" });

void DisplayStudents(string[] students)
{
    foreach (string student in students)
    {
        Console.Write($"{student}, ");
    }
    Console.WriteLine();
}

// Code sample 2
double pi = 3.14159;
PrintCircleInfo(12);
PrintCircleInfo(24);

void PrintCircleArea(int radius)
{
    double area = pi * (radius * radius);
    Console.WriteLine($"Area = {area}");
}

void PrintCircleCircumference(int radius)
{
    double circumference = 2 * pi * radius;
    Console.WriteLine($"Circumference = {circumference}");
}

void PrintCircleInfo(int radius) 
{
    Console.WriteLine($"Circle with radius {radius}");
    PrintCircleArea(radius);
    PrintCircleCircumference(radius);
}

// Pass by value
int a = 3;
int b = 4;
int c = 0;

Multiply(a, b, c);
Console.WriteLine($"global statement: {a} x {b} = {c}");

void Multiply(int a, int b, int c) 
{
    c = a * b;
    Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
}

// Pass by reference (Array is a reference type and is mutable)
int[] array = {1, 2, 3, 4, 5};

PrintArray(array);
Clear(array);
PrintArray(array);

void PrintArray(int[] array) 
{
    foreach (int a in array) 
    {
        Console.Write($"{a} ");
    }
    Console.WriteLine();
}

void Clear(int[] array) 
{
    for (int i = 0; i < array.Length; i++) 
    {
        array[i] = 0;
    }
}

// Pass by reference (String is a reference type but immutable)
// The value "status" does not change in the caller method.
// A new string is created inside SetHealth and discarded after the method ends.
string status = "Healthy";

Console.WriteLine($"Start: {status}");
SetHealth(status, false);
Console.WriteLine($"End: {status}");

void SetHealth(string status, bool isHealthy) 
{
    status = (isHealthy ? "Healthy" : "Unhealthy");
    Console.WriteLine($"Middle: {status}");
}

// Global variable is being modified inside the method
// This works because 'status' is declared in the outer (global) scope
// So it's not pass-by-reference, but rather direct access to a shared variable
string status = "Healthy";

Console.WriteLine($"Start: {status}");
SetHealth(false);
Console.WriteLine($"End: {status}");

void SetHealth(bool isHealthy) 
{
    status = (isHealthy ? "Healthy" : "Unhealthy");
    Console.WriteLine($"Middle: {status}");
}

// Methods with named and optional parameters
string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
string[] rsvps = new string[10];
int count = 0; 

// Calling the RSVP method with different argument styles

// Only name is provided. Other parameters take default values:
// partySize = 1, allergies = "none", inviteOnly = true
RSVP("Rebecca");

// Positional arguments for name, partySize, and allergies. inviteOnly defaults to true.
RSVP("Nadia", 2, "Nuts");

// Named parameters used. Allergies is not specified, so it defaults to "none".
// inviteOnly is false, so she doesn't need to be on the guest list.
RSVP(name: "Linh", partySize: 2, inviteOnly: false);

// Mixed positional and named arguments. Name is positional, others are named.
// partySize not specified, so defaults to 1.
RSVP("Tony", allergies: "Jackfruit", inviteOnly: true);

// Positional arguments for name and partySize. allergies defaults to "none".
// Named argument used for inviteOnly = false.
RSVP("Noor", 4, inviteOnly: false);

// All parameters are specified using positional arguments.
RSVP("Jonte", 2, "Stone fruit", false);

ShowRSVPs();

// RSVP method using optional parameters
void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)
{
    if (inviteOnly)
    {
        bool found = false;
        foreach (string guest in guestList)
        {
            if (guest.Equals(name))
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Sorry, {name} is not on the guest list");
            return;
        }
    }

    rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
    count++;
}

void ShowRSVPs()
{
    Console.WriteLine("\nTotal RSVPs:");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(rsvps[i]);
    }
}

================================================================================
NOTE: Create C# methods
================================================================================
// The process of developing a method begins with creating a method signature. 
// The method signature declares the method's return type, name, and input parameters.
// For example, consider the following method signature:
// void SayHello();

// Method definition
void SayHello()
{
    Console.WriteLine("Hello World!");
}

// Calling a method
SayHello();

// A method can be called before or after its definition. For example, the SayHello 
// method can be defined and called using the following syntax:

// Code sample 1
SayHello();

void SayHello() 
{
    Console.WriteLine("Hello World!");
}

// Code sample 2
int[] a = {1,2,3,4,5};

Console.WriteLine("Contents of Array:");
PrintArray();

void PrintArray()
{
    foreach (int x in a)
    {
        Console.Write($"{x} ");
    }
    Console.WriteLine();
}

// Method execution
// When you call a method, the code in the method body will be executed. This means 
// execution control is passed from the method caller to the method. Control is returned 
// to the caller after the method completes its execution. For example, consider the 
// following code:
Console.WriteLine("Before calling a method");
SayHello();
Console.WriteLine("After calling a method");

void SayHello() 
{
    Console.WriteLine("Hello World!");
}

// Output:
// Before calling a method
// Hello World!
// After calling a method

// Best practices
// When choosing a method name, it's important to keep the name concise and make 
// it clear what task the method performs. Method names should be Pascal case and 
// generally shouldn't start with digits. Names for parameters should describe what 
// kind of information the parameter represents. Consider the following method signatures:
// The second method describes what kind of data is displayed and provides descriptive names for parameters.
void ShowData(string a, int b, int c);
void DisplayDate(string month, int day, int year);

================================================================================
NOTE: String data type helper methods for modifying it's content
================================================================================
// IndexOf() method
string message = "Find what is (inside the parentheses)";

int openingPosition = message.IndexOf('(');
int closingPosition = message.IndexOf(')');

Console.WriteLine(openingPosition); // Output: 13
Console.WriteLine(closingPosition); // Output: 36

// Substring() method

// Code sample 1
string message = "Find what is (inside the parentheses)";

int openingPosition = message.IndexOf('(');
int closingPosition = message.IndexOf(')');

int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length)); // Output: (inside the parentheses

openingPosition += 1;
length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length)); // Output: inside the parentheses

// Code sample 2
string message = "What is the value <span>between the tags</span>?";

int openingPosition = message.IndexOf("<span>");
int closingPosition = message.IndexOf("</span>");

openingPosition += 6;
int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length));

// Code sample 3 - use of const keyword to avoid magic values that is hard coded string and it's length value
string message = "What is the value <span>between the tags</span>?";

const string openSpan = "<span>";
const string closeSpan = "</span>";

int openingPosition = message.IndexOf(openSpan);
int closingPosition = message.IndexOf(closeSpan);

openingPosition += openSpan.Length;
int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length));

// LastIndexOf() method

// Code sample 1
string message = "hello there!";

int first_h = message.IndexOf('h');
int last_h = message.LastIndexOf('h');

Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}.");

// Output: 
// For the message: 'hello there!', the first 'h' is at position 0 and the last 'h' is at position 7.

// Code sample 2
string message = "(What if) I am (only interested) in the last (set of parentheses)?";
int openingPosition = message.LastIndexOf('(');

openingPosition += 1;
int closingPosition = message.LastIndexOf(')');
int length = closingPosition - openingPosition;
Console.WriteLine(message.Substring(openingPosition, length)); // Output: set of parentheses

// Retrieve all instances of substrings inside parentheses
string message = "(What if) there are (more than) one (set of parentheses)?";
while (true)
{
    int openingPosition = message.IndexOf('(');
    if (openingPosition == -1) break;

    openingPosition += 1;
    int closingPosition = message.IndexOf(')');
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));

    // Note the overload of the Substring to return only the remaining 
    // unprocessed message:
    message = message.Substring(closingPosition + 1);
}

// Output:
// What if
// more than
// set of parentheses

// IndexOfAny() method

// Code sample 1
string message = "Hello, world!";
char[] charsToFind = { 'a', 'e', 'i' };

int index = message.IndexOfAny(charsToFind);

Console.WriteLine($"Found '{message[index]}' in '{message}' at index: {index}.");

// Code sample 2
string message = "Help (find) the {opening symbols}";
Console.WriteLine($"Searching THIS Message: {message}");
char[] openSymbols = { '[', '{', '(' };
int startPosition = 5;
int openingPosition = message.IndexOfAny(openSymbols);
Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");

openingPosition = message.IndexOfAny(openSymbols, startPosition);
Console.WriteLine($"Found WITH using startPosition {startPosition}:  {message.Substring(openingPosition)}");

// Find different substrings that is with in different symbols
string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

// The IndexOfAny() helper method requires a char array of characters. 
// You want to look for:

char[] openSymbols = { '[', '{', '(' };

// You'll use a slightly different technique for iterating through 
// the characters in the string. This time, use the closing 
// position of the previous iteration as the starting index for the 
// next open symbol. So, you need to initialize the closingPosition 
// variable to zero:

int closingPosition = 0;

while (true)
{
    int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

    if (openingPosition == -1) break;

    string currentSymbol = message.Substring(openingPosition, 1);

    // Now  find the matching closing symbol
    char matchingSymbol = ' ';

    switch (currentSymbol)
    {
        case "[":
            matchingSymbol = ']';
            break;
        case "{":
            matchingSymbol = '}';
            break;
        case "(":
            matchingSymbol = ')';
            break;
    }

    // To find the closingPosition, use an overload of the IndexOf method to specify 
    // that the search for the matchingSymbol should start at the openingPosition in the string. 

    openingPosition += 1;
    closingPosition = message.IndexOf(matchingSymbol, openingPosition);

    // Finally, use the techniques you've already learned to display the sub-string:

    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}

// Output:
// What if
// different symbols
// open symbol
// matching closing symbol

// Remove() method
string data = "12345John Smith          5000  3  ";
string updatedData = data.Remove(5, 20);
Console.WriteLine(updatedData); // Output: 123455000  3
Console.WriteLine(data);

// Replace() method
string message = "This--is--ex-amp-le--da-ta";
message = message.Replace("--", " ");
message = message.Replace("-", "");
Console.WriteLine(message); // Output: This is example data

================================================================================
NOTE: String data type built in methods
================================================================================
// A brief list of categories of these built-in methods so you can get an idea of what's possible.
// - Methods that add blank spaces for formatting purposes (PadLeft(), PadRight())
// - Methods that compare two strings or facilitate comparison (Trim(), TrimStart(), TrimEnd(), GetHashcode(), the Length property)
// - Methods that help you determine what's inside of a string, or even retrieve just a part of the string (Contains(), StartsWith(), EndsWith(), Substring())
// - Methods that change the content of the string by replacing, inserting, or removing parts (Replace(), Insert(), Remove())
// - Methods that turn a string into an array of strings or characters (Split(), ToCharArray())

// PadLeft() method
string input = "Pad this";
Console.WriteLine(input.PadLeft(12));

// Output: 
//     Pad this (When you run the code, you observe four characters prefixed to the left of the string bring the length to 12 characters long.)

// PadRight() method
string input = "Pad this";
Console.WriteLine(input.PadRight(12));

// Output: 
// Pad this    (When you run the code, you observe four characters suffixed to the right of the string bring the length to 12 characters long.)

// PadLeft() overloaded method
string input = "Pad this";
Console.WriteLine(input.PadLeft(12, '-'));

// Output: 
// ----Pad this

// PadRight() overloaded method
string input = "Pad this";
Console.WriteLine(input.PadRight(12, '-'));

// Output: 
// Pad this----

================================================================================
NOTE: Format specifiers
================================================================================
// Composite formatting and string interpolation can be used to format values for 
// display given a specific language and culture. In the following example, 
// the :C currency format specifier is used to present the price and discount 
// variables as currency. Update your code as follows:

// Currency format specifier (:C)
decimal price = 123.45m;
int discount = 50;
Console.WriteLine($"Price: {price:C} (Save {discount:C})"); // Output: Price: $123.45 (Save $50.00)

// Numeric format specifier (:N & :N4 or :N6)
decimal measurement = 123456.78912m;
Console.WriteLine($"Measurement: {measurement:N} units"); // Not precise
Console.WriteLine($"Measurement: {measurement:N4} units"); // More precise by adding number next to :N

// Output:
// Measurement: 123,456.79 units
// Measurement: 123,456.7891 units

// Percentage format specifier (:P)
decimal tax = .36785m;
Console.WriteLine($"Tax rate: {tax:P2}"); // Output: Tax rate: 36.79%

// Using format specifiers in composite formating
decimal price = 67.55m;
decimal salePrice = 59.99m;

string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

Console.WriteLine(yourDiscount); // Output: You saved $7.56 off the regular $67.55 price.

// Combining format specifier along with interpolation and composite formating
decimal price = 67.55m;
decimal salePrice = 59.99m;

string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

yourDiscount += $"A discount of {((price - salePrice)/price):P2}!"; //inserted
Console.WriteLine(yourDiscount); // Output: You saved $7.56 off the regular $67.55 price. A discount of 11.19%!

================================================================================
NOTE: Composite formating
================================================================================
// - Composite formatting allows you to insert values into a string by using numbered placeholders like {0}, {1}, etc.
// - These placeholders refer to the position of the arguments passed into the formatting method.
// - Useful when you want to format complex strings in a clear and readable way.

// Code sample 1
string first = "Hello";
string second = "World";
string result = string.Format("{0} {1}!", first, second);
Console.WriteLine(result); // Output: Hello World!

// Code sample 2
string first = "Hello";
string second = "World";
Console.WriteLine("{1} {0}!", first, second); // Output: World Hello!
Console.WriteLine("{0} {0} {0}!", first, second); // Output: Hello Hello Hello!

================================================================================
NOTE: Reverse words in a sentence challenge
================================================================================
string pangram = "The quick brown fox jumps over the lazy dog";
string[] message = pangram.Split(' ');
string[] newMessage = new string[message.Length];

for (int i = 0; i < message.Length; i++)
{
    char[] letters = message[i].ToCharArray();
    Array.Reverse(letters);
    newMessage[i] = new string(letters);
}

string result = String.Join(" ", newMessage);
Console.WriteLine(result);

================================================================================
NOTE: Array helper methods
================================================================================
// Array.Sort() method
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("Sorted...");
Array.Sort(pallets);
foreach (var pallet in pallets)
    Console.WriteLine($"-- {pallet}");

// Output:
// -- A11
// -- A13
// -- B12
// -- B14

// Array.Reverse() method
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("Reversed...");
Array.Reverse(pallets);
foreach (var pallet in pallets)
    Console.WriteLine($"-- {pallet}");

// Output:
// -- A13
// -- B12
// -- A11
// -- B14

// Array.Clear() method
string[] pallets = [ "B14", "A11", "B12", "A13" ];
Console.WriteLine("");

Array.Clear(pallets, 0, 2); // 0 is the starting index and 2 is the clearing elements
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
    Console.WriteLine($"-- {pallet}");

// Output: The clared values are null and not string, when called C# converts the null to string implicitly
// Clearing 2 ... count: 4
// --
// --
// B12
// A13

// Array.Resize() method to add elements
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");
foreach (var pallet in pallets)
    Console.WriteLine($"-- {pallet}");

// Output:
// Resizing 6 ... count: 6
// -- B14
// -- A11
// -- B12
// -- A13
// -- 
// -- 

// Array.Resize() method to remove elements
string[] pallets = ["B14", "A11", "B12", "A13"];

Console.WriteLine("");
Array.Resize(ref pallets, 3);
Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");
foreach (var pallet in pallets)
    Console.WriteLine($"-- {pallet}");

// Output:
// Resizing 3 ... count: 3
// -- B14
// -- A11
// -- B12

// ToCharArray() to reverse a string
string value = "abc123";
char[] valueArray = value.ToCharArray(); // ['a', 'b', 'c', '1', '2', '3']
Array.Reverse(valueArray); // ['3', '2', '1', 'c', 'b', 'a']
string result = new string(valueArray); // Passes the char array to the string class constructor that creates a string
Console.WriteLine(result); // Output: 321cba

// String.Join() method
string value = "abc123";
char[] valueArray = value.ToCharArray(); // ['a', 'b', 'c', '1', '2', '3']
Array.Reverse(valueArray); // ['3', '2', '1', 'c', 'b', 'a']
string result = String.Join(",", valueArray); // "3,2,1,c,b,a"
Console.WriteLine(result); // Output: 3,2,1,c,b,a

// Split() method
string value = "abc123";
char[] valueArray = value.ToCharArray(); // ['a', 'b', 'c', '1', '2', '3']
Array.Reverse(valueArray); // ['3', '2', '1', 'c', 'b', 'a']
string result = String.Join(",", valueArray); // "3,2,1,c,b,a"
Console.WriteLine(result);

string[] items = result.Split(','); // ['3', '2', '1', 'c', 'b', 'a']
foreach (string item in items)
    Console.WriteLine(item);

// Output: 
// 3,2,1,c,b,a
// 3
// 2
// 1
// c
// b
// a

================================================================================
NOTE: Math operations as specific number type challenge
================================================================================
int value1 = 11;
decimal value2 = 6.2m;
float value3 = 4.3f;

int result1 = Convert.ToInt32(value1 / value2);
decimal result2 = value2 / (decimal)value3;
float result3 = value3 / value1;

Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

// Your code here to set result2
Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

// Your code here to set result3
Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");

================================================================================
NOTE: Combining string array values as strings and as integers challenge
================================================================================
string[] values = { "12.3", "45", "ABC", "11", "DEF" };
string message = "";
decimal total = 0m;

foreach (var value in values)
{
    if (decimal.TryParse(value, out decimal result))
        total += result;
    else
        message += value;
}

Console.WriteLine($"Message: {message}"); // Output: Message: ABCDEF
Console.WriteLine($"Total: {total}"); // Output: Total: 68.3

================================================================================
NOTE: Data casting and conversion techniques
================================================================================
// Data casting

// Narrowing conversion
// The term narrowing conversion means that you're attempting to convert a value 
// from a data type that can hold more information to a data type that can hold 
// less information. In this case, you may lose information such as precision 
// (that is, the number of values after the decimal point). An example is converting 
// value stored in a variable of type decimal into a variable of type int. If you print 
// the two values, you would possibly notice the loss of information. When you know 
// you're performing a narrowing conversion, you need to perform a cast. Casting is 
// an instruction to the C# compiler that you know precision may be lost, but you're 
// willing to accept it.
decimal myDecimal = 3.14m;
Console.WriteLine($"decimal: {myDecimal}"); // Output: decimal: 3.14

int myInt = (int)myDecimal; // Explicit cast
Console.WriteLine($"int: {myInt}"); // Output: int: 3 (data loss)

// Data conversions

// Widening conversion
// The term widening conversion means that you're attempting to convert a value 
// from a data type that could hold less information to a data type that can hold 
// more information. In this case, a value stored in a variable of type int 
// converted to a variable of type decimal, doesn't lose information. When you know 
// you're performing a widening conversion, you can rely on implicit conversion. 
// The compiler handles implicit conversions.
int myInt = 3;
Console.WriteLine($"int: {myInt}"); // Output: int: 3

decimal myDecimal = myInt; // Implicit cast
Console.WriteLine($"decimal: {myDecimal}"); // Output: decimal: 3

// To perform data conversion, you can use one of several techniques:
// - Use a helper method on the data type
// - Use a helper method on the variable
// - Use the Convert class' methods

// ToString() to convert a number to a string
int first = 5;
int second = 7;
string message = first.ToString() + second.ToString();
Console.WriteLine(message); // Output: 57

// Parse() helper method
string first = "5";
string second = "7";
// The parse method could thorw error if any one of the string above is a non-numeric value so to mitigate use TryParse
int sum = int.Parse(first) + int.Parse(second); 
Console.WriteLine(sum); // Output: 12

// Convert class
// Convert.ToInt32() method with a string here, should probably use TryParse() when possible. 
// So, when should you use the Convert class? The Convert class is best for converting 
// fractional numbers into whole numbers (int) because it rounds up the way you would expect.
string value1 = "5";
string value2 = "7";
int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
Console.WriteLine(result);

// Casting vs Convert
int value = (int)1.5m; // casting truncates
Console.WriteLine(value); // Output: 1

int value2 = Convert.ToInt32(1.5m); // converting rounds up
Console.WriteLine(value2); // Output: 2

// TryParse()
string value = "102";
int result = 0;
if (int.TryParse(value, out result))
    Console.WriteLine($"Measurement: {result}");
else
    Console.WriteLine("Unable to report the measurement.");

================================================================================
NOTE: Practical concerns using value and reference types
================================================================================
// Value type
int val_A = 2;
int val_B = val_A;
val_B = 5;

Console.WriteLine("--Value Types--"); // Output: --Value Types--
Console.WriteLine($"val_A: {val_A}"); // Output: val_A: 2
Console.WriteLine($"val_B: {val_B}"); // Output: val_B: 5

// Reference type
int[] ref_A= new int[1];
ref_A[0] = 2;
int[] ref_B = ref_A;
ref_B[0] = 5;

Console.WriteLine("--Reference Types--");   // Output: --Reference Types--
Console.WriteLine($"ref_A[0]: {ref_A[0]}"); // Output: ref_A[0]: 5
Console.WriteLine($"ref_B[0]: {ref_B[0]}"); // Output: ref_B[0]: 5

================================================================================
NOTE: Reference types
================================================================================
// Declaration without initialization
int[] data; // 'data' is a null reference at this point (does not point to any memory).

// Initialization
data = new int[3]; 
// - The 'new' keyword allocates memory for 3 integers.
// - The variable 'data' holds the reference (memory address) of the first element.
// - The .NET runtime requests *contiguous memory*, meaning the next two integers are placed right after the first.
// - Arrays in C# are *reference types* even if they store value types (like int).

================================================================================
NOTE: Floating point types
================================================================================
Console.WriteLine("");
Console.WriteLine("Floating point types:");
Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");

================================================================================
NOTE: Unsigned integral types
================================================================================
Console.WriteLine("");
Console.WriteLine("Unsigned integral types:");

Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

================================================================================
NOTE: Signed integral types
================================================================================
Console.WriteLine("Signed integral types:");

Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

================================================================================
NOTE: Multidimensional array
================================================================================
// A multidimensional array (e.g., 2D array) is a grid-like structure
// with rows and columns of equal size. All rows must be the same length.
// More suitable for matrix-style data (e.g., a chess board or a game map).

string[,] multiArray = new string[,]
{
    { "one1", "two1", "three1" },
    { "one2", "two2", "three2" },
    { "one3", "two3", "three3" }
};

for (int row = 0; row < multiArray.GetLength(0); row++)
{
    for (int col = 0; col < multiArray.GetLength(1); col++)
    {
        Console.Write($"{multiArray[row, col]} ");
    }
    Console.WriteLine();
}

// Accessing an element
string element = multiArray[1, 2]; // Output: three2

================================================================================
NOTE: Jagged array
================================================================================
// A jagged array is an array of arrays. Each element is itself an array, 
// allowing different sizes (lengths) for each sub-array.
// This structure is useful when each row might have a different number of columns.
// Memory-efficient and flexible for irregular data like a list of lists.

string[][] jaggedArray = new string[][]
{
    new string[] { "one1", "two1", "three1", "four1", "five1", "six1" },
    new string[] { "one2", "two2", "three2", "four2", "five2", "six2" },
    new string[] { "one3", "two3", "three3", "four3", "five3", "six3" },
    new string[] { "one4", "two4", "three4", "four4", "five4", "six4" },
    new string[] { "one5", "two5", "three5", "four5", "five5", "six5" },
    new string[] { "one6", "two6", "three6", "four6", "five6", "six6" },
    new string[] { "one7", "two7", "three7", "four7", "five7", "six7" },
    new string[] { "one8", "two8", "three8", "four8", "five8", "six8" }
};

foreach (string[] array in jaggedArray)
{
    foreach (string val in array) // can't reuse 'value' — same scope rule
    {
        Console.Write($"{val} ");
    }
    Console.WriteLine();
}

// Accessing the value
string value = jaggedArray[0][3]; // Output: four1

================================================================================
NOTE: int.TryParse() method
================================================================================
int numericValue = 0;
bool validNumber = false;

validNumber = int.TryParse(readResult, out numericValue);

================================================================================
NOTE: String length validator program
================================================================================
string? readResult;
bool validEntry = false;
Console.WriteLine("Enter a string containing at least three characters:");
do
{
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        if (readResult.Length >= 3)
        {
            validEntry = true;
        }
        else
        {
            Console.WriteLine("Your input is invalid, please try again.");
        }
    }
} while (validEntry == false);

================================================================================
NOTE: Manage user input
================================================================================
// When using a Console.ReadLine() statement to obtain user input, it's common 
// practice to use a nullable type string (designated string?) for the input 
// variable and then evaluate the value entered by the user. The following 
// code sample uses a nullable type string to capture user input. The iteration 
// continues while the user-supplied value is null string? readResult;

Console.WriteLine("Enter a string:");
do
{
    readResult = Console.ReadLine();
} while (readResult == null);

================================================================================
NOTE: continue statement 
================================================================================
// continue statement transfers execution to the end of the current iteration

Random random = new Random();
int current = random.Next(1, 11);

do
{
    current = random.Next(1, 11);

    if (current >= 8) continue;

    Console.WriteLine(current);
} while (current != 7);

================================================================================
NOTE: while statement
================================================================================
Random random = new();
int current = random.Next(1, 11);

while (current >= 3)
{
    Console.WriteLine(current);
    current = random.Next(1, 11);
}

Console.WriteLine($"Last number: {current}");

================================================================================
NOTE: do-while statement
================================================================================
// It's important to notice that the code inside of the code block is influencing 
// whether to continue iterating through the code block or not. A code block that 
// influences the exit criteria is a primary reason to select a do-while or while 
// statements rather than one of the other iteration statements. Both the foreach 
// and for rely on factors that are external to the code block to determine the 
// number of code block iterations.

Random random = new Random();
int current = 0;

do
{
    current = random.Next(1, 11);
    Console.WriteLine(current);
} while (current != 7);

================================================================================
NOTE: for statement
================================================================================
// Count up
for (int i = 0; i < 10; i++)
    Console.WriteLine(i);

// Count down
for (int i = 10; i >= 0; i--)
    Console.WriteLine(i);

// Skip past certain values
for (int i = 0; i < 10; i += 3)
    Console.WriteLine(i);

// break key word to break the iteration statement
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    if (i == 7) break;
}

// Loop through array elements
string[] names = { "Alex", "Eddie", "David", "Michael" };
for (int i = names.Length - 1; i >= 0; i--)
{
    Console.WriteLine(names[i]);
}

// foreach limitation
string[] names = { "Alex", "Eddie", "David", "Michael" };
foreach (var name in names)
{
    // Can't do this: Cannot assign to name because it is a 'foreach iteration variable'
    if (name == "David") name = "Sammy";
}

// Updating contents of an array inside iteration code block of for
string[] names = { "Alex", "Eddie", "David", "Michael" };
for (int i = 0; i < names.Length; i++)
    if (names[i] == "David") names[i] = "Sammy";

foreach (var name in names) Console.WriteLine(name);

================================================================================
NOTE: switch statement
================================================================================
int employeeLevel = 200;
string employeeName = "John Smith";

string title = "";

switch (employeeLevel)
{
    case 100:
        title = "Junior Associate";
        break;
    case 200:
        title = "Senior Associate";
        break;
    case 300:
        title = "Manager";
        break;
    case 400:
        title = "Senior Manager";
        break;
    default:
        title = "Associate";
        break;
}

Console.WriteLine($"{employeeName}, {title}");

================================================================================
NOTE: Compiler's interpretation of variable scope
================================================================================
// Code sample 1 
// Compiler accounts for 2 possible execution paths because of the flag variable. 
// So when building this code sample, the compiler throws error.

bool flag = true;
int value;

if (flag)
{
    value = 10;
    Console.WriteLine($"Inside the code block: {value}");
}

Console.WriteLine($"Outside the code block: {value}");

// Code sample 2
// Since the selection statement be always true of the literal bool value,
// compiler consider one execution path and won't throw any error during build

int value;

if (true)
{
    value = 10;
    Console.WriteLine($"Inside the code block: {value}");
}

Console.WriteLine($"Outside the code block: {value}");

// Code sample 3
// This example shows variable redeclaration in separate block scopes.
// The `value` variables are independent because they are in different blocks.

{
    int value = 100;
    Console.WriteLine($"Inside first block: {value}");
}

{
    int value = 200; // No error – new block scope
    Console.WriteLine($"Inside second block: {value}");

    // Error: Cannot reuse 'value' here – already declared in the same block above
    // To fix, use a different variable name inside the foreach loop
    foreach (string item in new string[] { "apple", "orange" })
    {
        Console.WriteLine(item);
    }
}

================================================================================
NOTE: Code block and variable scope
================================================================================
bool flag = true;
if (flag)
{
    int value = 10;
    Console.WriteLine($"Inside the code block: {value}");
}
// Below statement throws error because variable value doesn't exist outside the code block
Console.WriteLine($"Outside the code block: {value}"); 

================================================================================
NOTE: Conditional operator or ternary conditional operator
================================================================================
int saleAmount = 1001;
// int discount = saleAmount > 1000 ? 100 : 50;

Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");

================================================================================
NOTE: Negation operator or not operator (!)
================================================================================
string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(!pangram.Contains("fox"));
Console.WriteLine(!pangram.Contains("cow"));

================================================================================
NOTE: string helper methods that returns bool
================================================================================
string pangram = "The quick brown fox jumps over the lazy dog.";
Console.WriteLine(pangram.Contains("fox"));
Console.WriteLine(pangram.Contains("cow"));

================================================================================
NOTE: Comparison operators
================================================================================
Console.WriteLine(1 > 2);
Console.WriteLine(1 < 2);
Console.WriteLine(1 >= 1);
Console.WriteLine(1 <= 1);

================================================================================
NOTE: Inequality operator
================================================================================
Console.WriteLine("a" != "a");
Console.WriteLine("a" != "A");
Console.WriteLine(1 != 2);

string myValue = "a";
Console.WriteLine(myValue != "a");

================================================================================
NOTE: string helper/utility methods to cleanup user input string
================================================================================
string value1 = " a";
string value2 = "A ";
Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

================================================================================
NOTE: Equality operator
================================================================================
Console.WriteLine("a" == "a");
Console.WriteLine("a" == "A");
Console.WriteLine("a" == "a ");
Console.WriteLine(1 == 2);

string myValue = "a";
Console.WriteLine(myValue == "a");

================================================================================
NOTE: Reverse message and count specific character program
================================================================================
string originalMessage = "The quick brown fox jumps over the lazy dog.";

char[] message = originalMessage.ToCharArray();
Array.Reverse(message);

int letterCount = 0;

foreach (char letter in message)
{
    if (letter == 'o')
    {
        letterCount++;
    }
}

string newMessage = new String(message);

Console.WriteLine(newMessage);
Console.WriteLine($"'o' appears {letterCount} times.");

================================================================================
NOTE: Generate random orderIDs for fraud testing
================================================================================
Random random = new Random();
string[] orderIDs = new string[5];

for (int i = 0; i < orderIDs.Length; i++)
{
    int prefixValue = random.Next(65, 70);
    string prefix = Convert.ToChar(prefixValue).ToString();
    string suffix = random.Next(1, 1000).ToString("000");

    orderIDs[i] = prefix + suffix;
}

foreach (var orderID in orderIDs)
{
    Console.WriteLine(orderID);
}

================================================================================
NOTE: Inventory audit
================================================================================
int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
int bin = 0;
foreach (int items in inventory)
{
    sum += items;
    bin++;
    Console.WriteLine($"Bin {bin} = {items} items (Running total: {sum})");
}

Console.WriteLine($"We have {sum} items in inventory.");

================================================================================
NOTE: foreach statement
================================================================================
string[] names = ["Rowena", "Robin", "Bao"];
foreach (string name in names)
{
    Console.WriteLine(name);
}

================================================================================
NOTE: Array initialization and length property
================================================================================
string[] fraudulentOrderIDs = ["A123", "B456", "C789"];
// Older syntax: string[] fraudulentOrderIDs = {"A123", "B456", "C789"};

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");

================================================================================
NOTE: Array declaration, setting and getting
================================================================================
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";
Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");

================================================================================
NOTE: string.Contains() method
================================================================================
string message = "The quick brown fox jumps over the lazy dog.";
bool result = message.Contains("dog");
Console.WriteLine(result);

if (message.Contains("fox"))
{
    Console.WriteLine("What does the fox say?");
}

================================================================================
NOTE: System.Math.Max() method
================================================================================
int firstValue = 500;
int secondValue = 600;
Console.WriteLine(Math.Max(firstValue, secondValue));

================================================================================
NOTE: Overloaded methods in Random class
================================================================================
Random dice = new Random();

int roll1 = dice.Next();
int roll2 = dice.Next(101);
int roll3 = dice.Next(50, 101);

Console.WriteLine($"First roll: {roll1}");
Console.WriteLine($"Second roll: {roll2}");
Console.WriteLine($"Third roll: {roll3}");

================================================================================
NOTE: Stateful vs. Stateless methods
================================================================================
Random dice = new Random();
int roll = dice.Next(1, 7);
Console.WriteLine(roll);

================================================================================
NOTE: Hello world
================================================================================
Console.WriteLine("Hello C#!");

*/