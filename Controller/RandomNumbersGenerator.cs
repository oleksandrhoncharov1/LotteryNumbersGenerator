using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumbersGenerator.Controller {
    public class RandomNumbersGenerator : IRandomNumbersGenerator {
        public IEnumerable<int> GenerateNumbers(int numbersAmount, int maxNumber) {
            if (numbersAmount == 0
                || numbersAmount < 1
                || maxNumber < numbersAmount)
                return null;
            
            var rnd = new Random();
            var numbers = Enumerable.Range(1, maxNumber).ToList();
            var result = new List<int>();

            for (int i = 0; i < numbersAmount; i++) {
                var index = rnd.Next(0, numbers.Count);
                result.Add(numbers[index]);
                numbers.RemoveAt(index);
            }

            result.Sort();

            return result;
        }
    }
}
