using System;

namespace Lab3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*privide info about students in a class
            *propt user for a particular student +
            *ask if user would like to learn about another student - loop +
            * 3 arrays : name, favorite food, previous title +
            * ask user which student they want to know about and take input +
            * convert input to integer +
            * ==make sure input is within range for arrays==+ 
            * ==prompt for corrected input if out of range==+
            * ask user what subcategory they want: food or title. take input. +
            * ==propt again if category entered is out of range==+
            * display relevent info+
            * loop back if user would like to learn about another student+
            * 
            * XXXXXXXXX
            * ==ask if user would like to learn more about student, find out about another, or quit.== 
            * ==provide an option where the user can see a list of all students==+
            * ==make input for category fault tolerant-take multiple relevent inputs for each category or check if it contains food or title instad of being a complete match==+
            */

            //initializing variables
            bool quit = false;
            bool loop = true;
            bool invalid = true;
            int firstInput = 0;

            string inputTest;

            string[] names = { "Henry David Thorax", "Levine Leventh", "Zubriant", "Clooney McNooney"};
            string[] food = { "pickled popcorn with sprinkled lemon zest", "space lasagna in a shere shape with corresponding layers with the Earth", "mulched lemon grass smothered in hotsauce", "ice cream but made with blue cheese instead of heavy cream" };
            string[] title = { "Head Editor for Newsweak", "Museum Curator in Belgium", "Actor/Musician", "Parking Attendent" };

            

            Console.Write("Welcome to our Dev.Build class. "); //don't want this to repeat

            while (quit == false)  // main loop
            {
                invalid = true; //resetting this for loops so I don't miss this next section the first run through.

                while (invalid == true)
                {

                    Console.Write("Which student would you like to learn more about?\n");
                    Console.Write($"(Enter number 0 for a directory or enter a number 1-{names.Length}): ");

                    
                    //int firstInput = Int32.Parse(Console.ReadLine());  //swapped this for more secure code

                    inputTest = Console.ReadLine();  //storing as a string to test
                    int x = 0;

                    if (Int32.TryParse(inputTest, out x))   //testing
                    {
                        firstInput = Int32.Parse(inputTest); //storing as an int

                        if (firstInput > names.Length || firstInput < 0)
                        {
                            Console.Write($"\nThat data does not exist. ");  //input invalid and will loop again.
                        }
                        else if (firstInput == 0)
                        {
                            for (int i = 0; i < names.Length; i++)
                            {
                                Console.Write($"{i+1} - {names[i]}\n");
                            }
                        }
                        else
                        {
                            invalid = false;                      // leaving loop
                        }


                        
                    }
                    else
                    {
                        Console.Write($"\nThat data does not exist. ");  //input invalid and will loop again. 
                    }

                }

                //Console.WriteLine(firstInput); //test

                int display = firstInput - 1 ;  // change the number to match the array instead of a user friendly option

                Console.Write($"\n\nStudent {firstInput} is {names[display]}. What would you like to know about {names[display]}? \n(enter \"favorite food\" or \"previous title\"): ");

                string secondInput = Console.ReadLine();  // storing what they want to know about

                secondInput = secondInput.ToLower(); //making it easier to match

                while (loop == true)   //looping to make sure user enters an accurate statement
                {


                    //if (secondInput == "favorite food")  // for favorite food
                    if (secondInput.Contains("fav") || secondInput.Contains( "favorite") || secondInput.Contains("food"))  //more generous with what user can input
                    {
                        Console.Write($"\n{names[display]}'s favorite food is {food[display]}.\n\n");
                        loop = false;  //to exit loop
                    }

                    //else if (secondInput == "previous title")  // for previous title
                    else if (secondInput.Contains("prev") || secondInput.Contains("previous") || secondInput.Contains("title")) // more generous on user input
                    {
                        Console.Write($"\n{names[display]}'s previous title was {title[display]}.\n\n");
                        loop = false;  //to exit loop
                    }

                    else  // for any other entry
                    {
                        Console.Write($"\nThat data does not exist. Please try again. (enter \"favorite food\" or \"previous title\"): ");
                        secondInput = Console.ReadLine();  // storing what they want to know about

                        secondInput = secondInput.ToLower(); //making it easier to match
                    }


                }

                Console.Write($"Would you like to know about another student? (enter \"yes\" or \"no\"): ");  //asking to do it all over

                secondInput = Console.ReadLine();
                secondInput = secondInput.ToLower(); // make it easier to parse

                if (secondInput.Contains("n"))  //exit loop
                {
                    quit = true;
                    
                }
                else
                {
                    Console.WriteLine();  //needed another line break

                    loop = true;  //needed for the next cycle
                }


            }
        }
    }
}
