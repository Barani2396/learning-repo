string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

string[,] ourAnimals = new string[maxPets, 7];

for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
        decimalDonation = 45.00m;

    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine();
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
        Console.Clear();
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                        Console.WriteLine(ourAnimals[i, j]);
                }
            }
            break;

        case "2":
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
                if (ourAnimals[i, 0] != "ID #: ")
                    petCount += 1;

            if (petCount < maxPets)
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;

                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower().Trim();

                        if (animalSpecies != "dog" && animalSpecies != "cat")
                            validEntry = false;

                        else
                            validEntry = true;
                    }
                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult.Trim();

                        if (animalAge != "?")
                            validEntry = int.TryParse(animalAge, out petAge);

                        else
                            validEntry = true;
                    }
                } while (validEntry == false);

                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();

                        if (animalPhysicalDescription == "")
                            animalPhysicalDescription = "tbd";
                    }
                } while (animalPhysicalDescription == "");

                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();

                        if (animalPersonalityDescription == "")
                            animalPersonalityDescription = "tbd";
                    }
                } while (animalPersonalityDescription == "");

                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();

                        if (animalNickname == "")
                            animalNickname = "tbd";
                    }
                } while (animalNickname == "");

                do
                {
                    Console.WriteLine("Enter a suggested donation for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        suggestedDonation = readResult.ToLower();

                        if (!decimal.TryParse(suggestedDonation, out decimalDonation))
                            decimalDonation = 45.00m;
                    }
                } while (decimalDonation == 0);

                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                ourAnimals[petCount, 6] = $"Suggested Donation: {decimalDonation:C2}";

                petCount = petCount + 1;

                if (petCount < maxPets)
                {
                    Console.WriteLine("\nDo you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                            anotherPet = readResult.ToLower();
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
                Console.WriteLine("\nWe have reached our limit on the number of pets that we can manage.");
            break;

        case "3":
            for (int i = 0; i < maxPets; i++)
            {
                animalID = ourAnimals[i, 0];
                if (animalID != "ID #: ")
                {
                    bool validEntry = false;
                    bool isAnimalAgeEmpty = ourAnimals[i, 2] == "Age: " || ourAnimals[i, 2] == "Age: ?";
                    if (isAnimalAgeEmpty)
                    {
                        int petAge;
                        do
                        {
                            Console.WriteLine($"\nEnter an age for {animalID}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                if (readResult != "?")
                                {
                                    validEntry = int.TryParse(readResult, out petAge);
                                    animalAge = petAge.ToString();
                                }
                                else
                                {
                                    validEntry = true;
                                    animalAge = readResult.Trim();
                                }
                            }
                        } while (validEntry == false);

                        ourAnimals[i, 2] = "Age: " + animalAge;
                    }

                    validEntry = false;
                    bool isAnimalPhysicalDescriptionEmpty = ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd";
                    if (isAnimalPhysicalDescriptionEmpty)
                    {
                        do
                        {
                            Console.WriteLine($"\nEnter a physical description for {animalID}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                if (readResult != "")
                                {
                                    animalPhysicalDescription = readResult;
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                    }
                }

                if (i == maxPets - 1)
                    Console.Write("\nAge and physical description fields are complete for all of our friends.\n");
            }
            break;

        case "4":
            for (int i = 0; i < maxPets; i++)
            {
                animalID = ourAnimals[i, 0];
                if (animalID != "ID #: ")
                {
                    bool validEntry = false;
                    bool isAnimalNicknameEmpty = ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd";
                    if (isAnimalNicknameEmpty)
                    {
                        do
                        {
                            Console.WriteLine($"\nEnter a nickname for {animalID}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                if (readResult != "")
                                {
                                    animalNickname = readResult;
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        ourAnimals[i, 3] = "Nickname: " + animalNickname;
                    }

                    validEntry = false;
                    bool isAnimalPersonalityDescriptionEmpty = ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 5] == "Personality: tbd";
                    if (isAnimalPersonalityDescriptionEmpty)
                    {
                        do
                        {
                            Console.WriteLine($"\nEnter a personality description for {animalID} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                if (readResult != "")
                                {
                                    animalPersonalityDescription = readResult;
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                    }
                }

                if (i == maxPets - 1)
                    Console.Write("\nNickname and personality description fields are complete for all of our friends.\n");
            }
            break;

        case "5":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;

        case "6":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;

        case "7":
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            break;

        case "8":
            string dogCharacteristics = "";

            while (dogCharacteristics == "")
            {
                Console.WriteLine($"\nEnter dog characteristics to search for separated by commas");
                readResult = Console.ReadLine();
                if (readResult != null)
                    dogCharacteristics = readResult.ToLower().Trim();
            }

            bool noMatchesDog = true;
            string dogDescription = "";
            string[] dogCharacteristicsArray = dogCharacteristics.Split(",");
            string[] searchingIcons = { "/ 2", "- 1 ", "\\ 1", "* 0" };

            Console.WriteLine("\n");

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    bool descriptionFound = false;
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];

                    foreach (string characteristic in dogCharacteristicsArray)
                    {
                        string dogName = ourAnimals[i, 3].Substring(ourAnimals[i, 3].IndexOf(" ")).Trim();
                        for (int j = 3; j > -1; j--)
                        {
                            foreach (string icon in searchingIcons)
                            {
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}\r");
                                Console.Write($"\rsearching our dog {dogName} for {characteristic.Trim()} {icon}");
                                Thread.Sleep(100);
                            }

                            Console.Write($"\r{new String(' ', Console.BufferWidth)}\r");
                        }

                        if (dogDescription.Contains(characteristic))
                        {
                            Console.WriteLine($"Our dog {dogName} is a {characteristic.Trim()} match!");
                            noMatchesDog = false;
                            descriptionFound = true;
                        }
                    }

                    if (descriptionFound)
                    {
                        Console.WriteLine(dogDescription);
                        Console.WriteLine();
                    }
                }
            }

            if (noMatchesDog)
                Console.Write("None of our dogs are a match found for: {0}\n", dogCharacteristics);
            break;

        default:
            break;
    }

    if (menuSelection != "exit" && menuSelection != "")
    {
        Console.WriteLine("\nPress the Enter key to continue.");
        readResult = Console.ReadLine();
    }
} while (menuSelection != "exit");