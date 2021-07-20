using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumbersGenerator.Model {
    public interface ILotteryRound
    {
        string Title { get; }
        IEnumerable<int> Numbers { get; }
    }
}
