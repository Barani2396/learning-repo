string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation = 0;

for (int i = 0; i < myStrings.Length; i++)
{
    string myString = myStrings[i];
    int pos = myString.IndexOf(".");
    if (pos > -1)
    {
        while (myString != "")
        {
            Console.WriteLine(myString.Substring(0, pos));
            myString = myString.Remove(0, pos + 1);
            myString = myString.TrimStart(' ');
            pos = myString.IndexOf(".");
            if (pos == -1)
            {
                Console.WriteLine(myString);
                myString = "";
            }
        }
    }
    else
    {
        Console.WriteLine(myString);
    }
}