string? readResult;
bool validEntry = false;

Console.WriteLine("Enter an integer value between 5 and 10:");

do
{
    readResult = Console.ReadLine();

    if (readResult != null)
    {
        int numericValue = 0;
        bool isNumber = int.TryParse(readResult, out numericValue);

        if (isNumber)
        {
            if (numericValue >= 5 && numericValue <= 10)
            {
                Console.WriteLine($"Your input value ({numericValue}) has been accepted.");
                validEntry = true;
                continue;
            }
            else
            {
                Console.WriteLine($"You entered {numericValue}. Please enter a number between 5 and 10.");
                continue;
            }
        }

        Console.WriteLine("Sorry, you entered an invalid number, please try again");
    }
} while (validEntry == false);