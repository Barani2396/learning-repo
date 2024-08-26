string? readResult;
bool validEntry = false;
int numericValue = 0;

Console.WriteLine("Enter integer value between 5 and 10");

do
{
    readResult = Console.ReadLine();
    bool validNumber = int.TryParse(readResult, out numericValue);
    if (readResult != null)
    {
        if (validNumber)
        {
            if (numericValue >= 5 && numericValue <= 10)
            {
                validEntry = true;
                Console.WriteLine("Input value is accepted");
            }
            else
            {
                Console.WriteLine($"You entered {numericValue}. Please enter a number between 5 and 10.");
            }
        }
        else
        {
            Console.WriteLine("Sorry, you entered an invalid number, please try again");
        }
    }
} while (!validEntry);