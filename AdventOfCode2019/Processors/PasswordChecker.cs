using System.Collections.Generic;

namespace AdventOfCode2019.Processors
{
    public class PasswordChecker
    {
        public bool CheckPassword(int number)
        {
            char[] numbers = number.ToString().ToCharArray();
            if (numbers.Length == 1) { return false; }

            Dictionary<char, int> charOccurences = new Dictionary<char, int>();

            bool containsExactlyTwoAdjacentDigits = false;
            bool digitsNeverDecrease = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 < numbers.Length)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        digitsNeverDecrease = false;
                        break;
                    }
                }
                else if (numbers[i] < numbers[i - 1])
                {
                    digitsNeverDecrease = false;
                    break;
                }

                if (!charOccurences.ContainsKey(numbers[i]))
                {
                    charOccurences.Add(numbers[i], 1);
                }
                else
                {
                    charOccurences[numbers[i]]++;
                }
            }

            if (digitsNeverDecrease && charOccurences.ContainsValue(2))
            {
                containsExactlyTwoAdjacentDigits = true;
            }

            return containsExactlyTwoAdjacentDigits && digitsNeverDecrease;
        }
    }
}
