string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation = 0;

for (int i = 0; i < myStrings.Length; i++)
{
    string myString = myStrings[i];
    periodLocation = myStrings[i].IndexOf(".");

    string mySentence;

    while (periodLocation != -1)
    {
        mySentence = myString.Substring(0, periodLocation);
        myString = myString.Remove(0, periodLocation + 1).TrimStart();
        periodLocation = myString.IndexOf(".");
        Console.WriteLine(mySentence);
    }

    mySentence = myString.Trim();
    Console.WriteLine(mySentence);
}