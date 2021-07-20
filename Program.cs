using LotteryNumbersGenerator.Controller;
using LotteryNumbersGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LotteryNumbersGenerator {
    class Program {
        private const int DEFAULT_NUMBERS_AMOUNT = 6;
        private const int DEFAULT_MAX_NUMBER = 49;

        static void Main(string[] args) {
            MainLoop(new RandomNumbersGenerator());
        }

        private static void MainLoop(IRandomNumbersGenerator randomNumbersGenerator) {
            int numbersAmount = DEFAULT_NUMBERS_AMOUNT;
            int maxNumber = DEFAULT_MAX_NUMBER;
            int roundNumber = 1;

            var defaultConsoleColore = Console.ForegroundColor;

            do {
                Console.ForegroundColor = defaultConsoleColore;

                Console.WriteLine($"Press any key to gerenerate {numbersAmount} random numbers from 1 to {maxNumber}.");
                Console.WriteLine("Press 'M' to change numbers range and amount.");
                Console.WriteLine("Press 'Q' to Exit.");
                var key = Console.ReadKey();

                if (key.KeyChar.Equals('q') || key.KeyChar.Equals('Q'))
                    return;

                if (key.KeyChar.Equals('m') || key.KeyChar.Equals('M')) {
                    Console.WriteLine();
                    Console.WriteLine("Enter numbers amount: ");
                    var str = Console.ReadLine();
                    int newNumbersAmount;
                    if(!int.TryParse(str, out newNumbersAmount)) {
                        Console.WriteLine($"Please next time enter numeric value");
                        Console.WriteLine();

                        continue;
                    }
                    

                    if (newNumbersAmount < 1 || newNumbersAmount > DEFAULT_MAX_NUMBER) {
                        Console.WriteLine($"Please next time enter value from 1 to {DEFAULT_MAX_NUMBER}");
                        Console.WriteLine();
                        
                        continue;
                    }
                        
                    numbersAmount = newNumbersAmount;
                }

                ILotteryRound current = new LotteryRound($"Round {roundNumber}",
                    randomNumbersGenerator.GenerateNumbers(numbersAmount, maxNumber));

                Console.WriteLine();
                Console.WriteLine($"======== {current.Title} ========");

                foreach (var number in current.Numbers) {
                    Console.ForegroundColor = DefineColor(number);

                    Console.Write($"{number}  ");
                }

                Console.WriteLine();
                Console.WriteLine();

                roundNumber++;
            } while (true);

            Console.ReadKey();
        }

        private static ConsoleColor DefineColor(int number) {
            //  we define c# version less than 7.0

            if (number > 0 && number <= 9)
                return ConsoleColor.Gray;
            if (number > 9 && number <= 19)
                return ConsoleColor.Blue;
            if (number > 19 && number <= 29)
                return ConsoleColor.Magenta;
            if (number > 29 && number <= 39)
                return ConsoleColor.Green;
            if (number > 39 && number <= 49)
                return ConsoleColor.Yellow;

            return ConsoleColor.White;
        }
    }
}
