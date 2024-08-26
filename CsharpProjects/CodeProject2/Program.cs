string? readResult;
string[] roles = { "administrator", "manager", "user" };
bool validEntry = false;

Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

do
{
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        int pos = Array.IndexOf(roles, readResult.Trim().ToLower());
        if (pos > -1)
        {
            Console.WriteLine($"Your input value ({char.ToUpper(roles[pos][0]) + roles[pos].Substring(1)}) has been accepted.");
            validEntry = true;
        }
        else
        {
            Console.WriteLine($"The role name that you entered, \"{readResult}\" is not valid.");
        }
    }
} while (!validEntry);


