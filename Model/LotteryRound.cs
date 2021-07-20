using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumbersGenerator.Model {
    public class LotteryRound : ILotteryRound {

        public LotteryRound(string title, IEnumerable<int> numbers) {
            Title = title;
            Numbers = numbers;
        }

        public string Title { get; }
        public IEnumerable<int> Numbers { get; }
    }
}
