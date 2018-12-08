using System;

namespace RoguelikeCharGen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize values used by I/O.
            string response = "";
            int gen = 0;

            //Introduce self to user.
            Console.WriteLine("Welcome to the character generator.");
            Console.WriteLine("Shall I generate you a character? yes/no");
            response = Console.ReadLine();

            //Start an endless loop of I/O until exited.
            for (;;)
            {

                if (response.ToLower() == "yes")
                {
                    gen++; //Increment how many characters have been generated this session.
                    Console.WriteLine("\nCharacter #" + gen + "\n"); //Write that number into the console.
                    string finalText = Combiner(); //Combiner does the actual generation.
                    Console.WriteLine(finalText); //Show the user the new character.
                    Console.WriteLine("Generate another? yes/no");
                    response = Console.ReadLine();
                }
                else if (response.ToLower() == "no")
                {
                    Console.WriteLine("\nAll right then. Press any key to exit.");
                    Console.ReadKey(); //Waits for one last input so the user can actually read this message.
                    return;
                }
                else
                {
                    Console.WriteLine("Uh, please enter Yes or No.");
                    response = Console.ReadLine(); //Simple default message for invalid input.
                }

            }

        }

        //Here's where we enter all the information that the generator uses
        //I could probably make some of this more elegant (Generator class?) but for now I'm just happy the thing works
        //It should continue to work no matter what size the arrays are

        static private string[] SpecList = { "Paladin", "Gladiator", "Ranger", "Rogue", "Necromancer", "Sorcerer", "Priest", "Bard" };
        static private string[] TraitList = { "Protective", "Aggressive", "Cautious", "Sneaky", "Resourceful", "Charismatic", "Gentle", "Imaginative" };
        static private string[] StatList = { "Strength", "Intelligence", "Dexterity" };
        static private string[] ResourceList = { "Health", "Mana", "Stamina" };

        static private int statMin = 5;
        static private int statMax = 15;
        static private int resourceMin = 25;
        static private int resourceMax = 75;

        static Random rng = new Random(); //Prepare for the pseudo-random number generation ahead
        //I avoided the error where generating this repeatedly instead of once would give repetitive results

        static string StringSelector(string[] currentArray)
            {
                string chosenString = currentArray[rng.Next(currentArray.Length)]; //Picks a random string from a specified array
                return chosenString;
            }

        static int IntSelector(int MinimumValue, int MaximumValue)
            {
                int chosenInt = rng.Next(MinimumValue, MaximumValue); //Picks a random integer from a specified range
                return chosenInt;
            }

        static string Combiner()
            {
            //For now we're going to put everything into this string rather than track it as separate variables
            //I would change this if I wanted to, for example, keep these variables stored long enough to 
            //base Stats off of Specs/Traits and Resources off of Stats
            string combinedString = "";
                combinedString += "Spec: " + StringSelector(SpecList) + "\n";
                combinedString += "Trait: " + StringSelector(TraitList) + "\n";
            //Other lists of strings would be super easy to add to this
            //Being able to have multiple traits from the same array would need a check to prevent duplicates though

                for (int currentStat = 0; currentStat < StatList.Length; currentStat++)
                    {
                        combinedString += StatList[currentStat] + ": " + IntSelector(statMin, statMax) + "\n";
                    }
                //Print out the name of each stat before generating it
                for (int currentResource = 0; currentResource < ResourceList.Length; currentResource++)
                    {
                        combinedString += ResourceList[currentResource] + ": " + IntSelector(resourceMin, resourceMax) + "\n";
                    }

                return combinedString; // and finally we send it all back to Main
            }
    }
}
