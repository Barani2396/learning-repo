string? readResult;
Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

while (true)
{
    readResult = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(readResult))
    {
        Console.WriteLine("Input cannot be empty. Enter your role name (Administrator, Manager, or User) Administrator");
        continue;
    }

    switch (readResult.ToLower())
    {
        case "administrator":
        case "manager":
        case "user":
            Console.WriteLine($"Your input value ({readResult}) has been accepted.");
            return;

        default:
            Console.WriteLine($"The role name that you entered, \"{readResult}\" is not valid. Enter your role name (Administrator, Manager, or User) Administrator");
            continue;
    }
}