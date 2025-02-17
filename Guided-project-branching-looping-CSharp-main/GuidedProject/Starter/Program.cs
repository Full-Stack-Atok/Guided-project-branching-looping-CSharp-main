// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
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
            break;

        case 1:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
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
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of out current pet information
            
            for (int i = 0; i < maxPets; i++) 
            {
                if (ourAnimals[i, 0] != "ID #: ") 
                {
                    Console.WriteLine();
                    for(int j = 0; j < 6; j++) 
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }

            Console.WriteLine("Press the enter to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            // Add a new animal friend to the ourAnimals array
            //
            // The ourAnimals array contains
            //    1. the species (cat or dog). a required field
            //    2. the ID number - for example C17
            //    3. the pet's age. can be blank at initial entry.
            //    4. the pet's nickname. can be blank.
            //    5. a description of the pet's physical appearance. can be blank.
            //    6. a description of the pet's personality. can be blank.
            
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++) 
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets) 
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            bool validEntry = false;

            do 
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry.");
                readResult = Console.ReadLine();

                if (readResult != null) 
                {
                    animalSpecies = readResult.ToLower();
                    if (animalSpecies != "dog" && animalSpecies != "cat")
                    {
                        validEntry = false;
                    }
                    else 
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);

            // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

            // get the pet's age. can be ? at initial entry.
            do
            {
                int petAge;
                Console.WriteLine("Enter the pet's age or enter ? if unknown.");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalAge = readResult;

                    if (animalAge != "?")
                    {
                        validEntry = int.TryParse(animalAge, out petAge);
                    }
                    else 
                    {
                        validEntry = true;
                    }
                }
            } while (validEntry == false);


            // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
            do
            {
                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();

                    if (animalPhysicalDescription == "")
                    {
                        animalPhysicalDescription = "tbd.";
                    }
                }
            } while ( animalPhysicalDescription == "");

            // get a description of the pet's personality - animalPersonalityDescription can be blank
            do
            {
                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                readResult = Console.ReadLine();

                if (readResult != null) 
                {
                    animalPersonalityDescription = readResult.ToLower();

                    if(animalPersonalityDescription == "")
                    {
                        animalPersonalityDescription = "tbd.";
                    }
                }
            }while (animalPersonalityDescription == "");
            
            // get the pet's nickname can be blank
            do 
            {
                Console.WriteLine("Enter a nickname for the pet");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();

                    if (animalNickname == "")
                    {
                        animalNickname = "tbd.";
                    }
                }
            } while(animalNickname == "");

            while (anotherPet == "y" && petCount < maxPets)
            {
                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;

                if(petCount < maxPets)
                {
                    // Another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do 
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while(anotherPet != "y" && anotherPet != "n");
                }
            }

            // Store the pet information in the ourAnimal array (zero based)
            ourAnimals[petCount, 0] = "ID #:" + animalID;
            ourAnimals[petCount, 1] = "Species: " + animalSpecies;
            ourAnimals[petCount, 2] = "Age: " + animalAge;
            ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
            ourAnimals[petCount, 4] = "Physical Condition: " + animalPhysicalDescription;
            ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

            if (petCount >= maxPets) 
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal age and physical description are complete
            Console.WriteLine("Ensuring all animal ages and physical descriptions are complete...\n");
            

            for (int i = 0; i < maxPets; i++)
            {
                // skip empty pets ("default "ID #: ")
                if (string.IsNullOrEmpty(ourAnimals[i, 0]) || ourAnimals[i, 0].Trim() == "ID #: ")
                {
                    continue;
                }

                Console.WriteLine($"{ourAnimals[i, 0]}, \n{ourAnimals[i, 1]}"); // Show ID & Species

                // Validate & Update Animal Age
                bool validAge = false;
                while(!validAge)
                {
                    Console.WriteLine($"Current Age: {ourAnimals[i, 2].Replace("Age: ", "")}. \nEnter new age (or press Enter to keep it.)");
                    string? inputAge = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(inputAge))
                    {
                        validAge = true;
                    }
                    
                    else if(int.TryParse(inputAge, out int validNumericAge) && validNumericAge > 0) // Check if numeric
                    {
                        ourAnimals[i, 2] = "Age: " + inputAge;
                        validAge = true;
                    }
                    else 
                    {
                        Console.WriteLine("Invalid age. Please enter a valid number.");
                    }
                }

                // Validate & Update Animal Physical Description
                bool validDescription = false;
                while (!validDescription)
                {
                    Console.WriteLine($"Current Physical Description: {ourAnimals[i, 4].Replace("Physical description: ", "")}. \nEnter new description (or press Enter to keep it.)");
                    string? inputDescription = Console.ReadLine()?.Trim(); // Trim whitespace
                    
                    if (string.IsNullOrEmpty(inputDescription))
                    {
                        validDescription = true;
                    }

                    else if (inputDescription.Length < 3 || inputDescription == "." || inputDescription == ".." || inputDescription.Length < 3)
                    {
                        Console.WriteLine("Description cannot be empty or too short. Please provide a valid description.");
                    }
                    else
                    {
                        ourAnimals [i, 4] = "Physical description: " + inputDescription;
                        validDescription = true;
                    }
                }

                Console.WriteLine(); // Spacing between animals
            }
            Console.WriteLine("\nAge and physical description fields are complete for all of our friends. \nPress Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure the animal nicknames and personality descriptions are complete
            Console.WriteLine("Ensuring animal nicknames and personality descriptions are complete...\n");

            for (int i = 0; i < maxPets; i++)
            {
                // skip uninitialized or empty pet entries
                if(string.IsNullOrWhiteSpace(ourAnimals[i, 0]) || ourAnimals[i, 0].Trim() == "ID #: ")
                {
                    continue;
                }

                Console.WriteLine($"{ourAnimals[i, 0]}, \n{ourAnimals[i, 1]}"); // show id and species

                // validate & update animal nickname
                bool validNickname = false;
                while (!validNickname)
                {
                    Console.WriteLine($"Current Nickname: {ourAnimals[i, 3].Replace("Nickname: ", "")}. \nEnter new nickname (or press Enter to kept it.)");
                    string? inputNickname = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(inputNickname))
                    {
                        validEntry = true;
                    }
                    else if (inputNickname.Length < 2 || inputNickname == "." || inputNickname == "..")
                    {
                        Console.WriteLine("Nickname cannot be empty or too short. Please provide a valid nickname.");
                    }
                    else
                    {
                        ourAnimals[i, 3] = "Nickname: " + inputNickname;
                        validNickname = true;
                    }
                }

                // validate & update animal personality description
                bool validPersonality = false;
                while(!validPersonality)
                {
                    Console.WriteLine($"Currently Personality Description: {ourAnimals[i, 5].Replace("Personality: ", "")}. \nEnter new personality description (or press Enter to keep it.)");
                    string? inputPersonality = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(inputPersonality))
                    {
                        validPersonality = true;
                    }
                    else if (inputPersonality.Length < 3 || inputPersonality == "." || inputPersonality == "..") 
                    {
                        Console.WriteLine("Personality description cannot be empty or too short. Please provide a valid description.");
                    }
                    else
                    {
                        ourAnimals[i, 5] = "Personality: " + inputPersonality;
                        validPersonality = true;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nNickname and personality description fields are complete for all of our friends. \nPress Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal’s age");
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            // Edit an animal’s personality description");
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
             // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;

    }
} while (menuSelection != "exit");





