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
            //welcome Statement


            //ask for input from user for the number of chips that they have
            Console.Write("Please enter the number of chips that you have: ");
            int numberOfUserChips = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Please enter the start and end color for each of the {numberOfUserChips} chips.");
            Console.WriteLine();
             
            //request input of colors for each chip labeling start and end
            List<ColorChip> userChips = new List<ColorChip>();

            int chipFormFieldNumber = 1;
            for (int i = 0; i < numberOfUserChips; i++)
            {
                string firstColor = "";
                string secondColor = "";


                Console.WriteLine($"Chip {chipFormFieldNumber}");
                Console.Write($"Enter start color: ");
                firstColor = Console.ReadLine();

                Console.Write($"Enter end color: ");
                secondColor = Console.ReadLine();
                Console.WriteLine();

                //Color startColor = (Color)Enum.Parse(typeof(Color), firstColor.Trim());
                //Color endColor = (Color)Enum.Parse(typeof(Color), secondColor.Trim());
                Color startColor = InputConversion(firstColor);
                Color endColor = InputConversion(secondColor);
                ColorChip enteredChip = new ColorChip(startColor, endColor);
                userChips.Add(enteredChip);
                chipFormFieldNumber++;
            }
            Console.WriteLine();

            Console.Write("Your chips: ");
            foreach (ColorChip userChip in userChips)
            {
                Console.Write($"[{userChip}]");
            }
            Console.WriteLine();


            //create valid chips list
            List<ColorChip>validCombonationOfChips = new List<ColorChip>();
            
            ColorChip firstChip = (ColorChip)userChips.FirstOrDefault(c => c.StartColor == Color.Blue);
            validCombonationOfChips.Add(firstChip); 
            
            //Defining Var For Linq Statement Sort
            Color chipEndColor = firstChip.EndColor;
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
                    Console.Write("Valid Combination: ");
                    foreach (ColorChip chip in validCombonationOfChips)
                    {
                        Console.Write($"[{chip}]");
                    }
                    Console.WriteLine();

                    break;
                }

                if (loopProtectionCount == 5 + numberOfUserChips)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    break;
                }
            }



            Console.ReadLine();


            Color InputConversion(string input) 
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
                    case "Orange":
                        return Color.Orange;
                    default:
                        Console.WriteLine("invalid color");
                        return Color.Orange;
                }
            }



        }
    }
}
