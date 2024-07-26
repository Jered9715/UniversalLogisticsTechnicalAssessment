using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                -Note From Dev-
                    Use of code:
                       - Must have one Token that starts with the color blue
                    Strength of code: 
                       - Chips do not have to be input in order for program to find a true combination
                       - End shows the order that chips need to be set in place for 
                    Weakness of code: 
                       - Will not always solve to use the largest number of chips if there are two combinations possible to allow for entry.
                       - Must have a blue start color on at least one chip. If I had more time I would like to add another Linq statement that would search the userChips list for the presense 
                         of at least one chip thats start color is blue and one that has the end color of green          
             */
            
            
            
            //Welcome Statement
            Console.WriteLine("Welcome To The Chip Set Security System");
            Console.WriteLine();

            //Define User Input
            Console.Write("Please enter the number of chips that you have: ");
            int numberOfUserChips = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Please enter the start and end color for each of the {numberOfUserChips} chips");
            Console.WriteLine();
             
            //List containing all user entered chips
            List<ColorChip> userChips = new List<ColorChip>();

            //Request input from user based on the number of chips they have
            int chipFormFieldNumber = 1;
            for (int i = 0; i < numberOfUserChips; i++)
            {
                string firstColorInput = "";
                string secondColorInput = "";

                Console.WriteLine($"Chip {chipFormFieldNumber}");

                Console.Write($"Enter start color: ");
                firstColorInput = Console.ReadLine();

                Console.Write($"Enter end color: ");
                secondColorInput = Console.ReadLine();
                Console.WriteLine();

                Color startColor = ConvertFromStringToEnum(firstColorInput);
                Color endColor = ConvertFromStringToEnum(secondColorInput);
                ColorChip enteredChip = new ColorChip(startColor, endColor);
                userChips.Add(enteredChip);
                chipFormFieldNumber++;
            }
            Console.WriteLine();

            //Display Chips in left to right format in order they were input
            Console.Write("Your chips: ");
            foreach (ColorChip userChip in userChips)
            {
                Console.Write($"[{userChip}]");
            }
            Console.WriteLine();


            //List used to show combination needed for unlocking
            List<ColorChip>validCombonationOfChips = new List<ColorChip>();
            
            //Establish first chip Linq search
            ColorChip firstChip = (ColorChip)userChips.FirstOrDefault(c => c.StartColor == Color.Blue);
            validCombonationOfChips.Add(firstChip); 
            
            //Sets Linq var to first search
            Color chipEndColor = firstChip.EndColor;
            
            //Protection added for inifinite loop. This was placed to allow for error message to run and break out of loop
            int loopProtectionCount = 0;
            while (true)
            {

                ColorChip Chip = (ColorChip)userChips.FirstOrDefault(c => c.StartColor == chipEndColor);
                validCombonationOfChips.Add(Chip);
                chipEndColor = Chip.EndColor;
                loopProtectionCount++;
                if (chipEndColor == Color.Green)
                {
                    Console.WriteLine();
                    Console.WriteLine("Can unlock master panel");
                    Console.WriteLine();
                    Console.Write("Valid combination: ");
                    foreach (ColorChip chip in validCombonationOfChips)
                    {
                        Console.Write($"[{chip}]");
                    }
                    Console.WriteLine();

                    break;
                }

                if (loopProtectionCount > numberOfUserChips )
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    break;
                }
            }

            Console.ReadLine();


            Color ConvertFromStringToEnum(string input) 
            {
                switch (input.ToLower().Trim()) 
                {
                    case "red":
                        return Color.Red;
                    case "green":
                        return Color.Green;
                    case "blue":
                        return Color.Blue;
                    case "yellow":
                        return Color.Yellow;
                    case "purple":
                        return Color.Purple;
                    case "orange":
                        return Color.Orange;
                    default:
                        Console.WriteLine("Invalid Input Default Color To Orange");
                        return Color.Orange;
                }
            }



        }
    }
}
