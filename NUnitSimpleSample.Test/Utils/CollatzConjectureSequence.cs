using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSimpleSample.Test.Utils
{
  public static class CollatzConjectureSequence
  {
    /// <summary>
    /// Returns a list based on the Lothar Collatz idea
    /// </summary>
    /// <param name="number">A negative number or non negative number</param>
    /// <returns>List of integer values</returns>
    public static IEnumerable<int> CollatzConjecture(int number)
    {
      List<int> numbers = new List<int>();

      while (number != 1)
      {
        if (number % 2 == 0)
        {
          number = number / 2;
        }
        else if (number % 2 == 1)
        {
          number = (3 * number) + 1;
        }
        numbers.Add(number);
      }

      return numbers;
    }

  }
}
