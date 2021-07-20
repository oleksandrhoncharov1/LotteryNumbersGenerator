using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumbersGenerator.Controller {
    public interface IRandomNumbersGenerator {
        IEnumerable<int> GenerateNumbers(int numbersAmount, int maxNumber);
    }
}
