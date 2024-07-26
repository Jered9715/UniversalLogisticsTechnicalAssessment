using System;
using System.Collections.Generic;
using System.Linq;
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
            int numberOfChips = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Please the start and end color for each of the {numberOfChips} chips.");
            Console.WriteLine();
             
            //request input of colors for each chip labeling start and end
            List<ColorChip> userChips = new List<ColorChip>();

            int chipViewNumber = 1;
            for (int i = 0; i < numberOfChips; i++)
            {
                string firstColor = "";
                string secondColor = "";

                Console.WriteLine($"Chip {chipViewNumber}");
                Console.Write($"Enter start color: ");
                firstColor = Console.ReadLine();

                Console.Write($"Enter end color: ");
                secondColor = Console.ReadLine();
                Console.WriteLine();

                Color startColor = (Color)Enum.Parse(typeof(Color), firstColor.Trim());
                Color endColor = (Color)Enum.Parse(typeof(Color), secondColor.Trim());
                ColorChip enteredChip = new ColorChip(startColor, endColor);
                userChips.Add(enteredChip);
                chipViewNumber++;
            }
            Console.WriteLine();

            Console.WriteLine("Your chips");
            foreach (ColorChip userChip in userChips)
            {
                Console.Write($"[{userChip}]");
            }
            Console.WriteLine();


            //create valid chips list
            List<ColorChip>validChipCombonation = new List<ColorChip>();
            
            ColorChip firstChip = (ColorChip)userChips.FirstOrDefault(c => c.StartColor == Color.Blue);
            validChipCombonation.Add(firstChip); 
            Color chipEndColor = firstChip.EndColor;
            int loopProtectionCount = 0;
            while (true)
            {
                ColorChip Chip = (ColorChip)userChips.FirstOrDefault(c => c.StartColor == chipEndColor);
                validChipCombonation.Add(Chip);
                chipEndColor = Chip.EndColor;
                loopProtectionCount++;
                if (chipEndColor == Color.Green)
                {
                    Console.WriteLine();
                    Console.WriteLine("You can unlock the house");
                    Console.WriteLine();
                    Console.WriteLine("Valid Combination");
                    foreach (ColorChip chip in validChipCombonation)
                    {
                        Console.Write($"[{chip}]");
                    }
                    Console.WriteLine();

                    break;
                }

                if (loopProtectionCount == 5 + numberOfChips)
                {
                    Console.WriteLine(Constants.ErrorMessage);
                    break;
                }
            }



            Console.ReadLine();





        }
    }
}
