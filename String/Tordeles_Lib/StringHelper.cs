using System.Text;

namespace Tordeles_Lib
{
    public static class StringHelper
    {
        public static string[] Split(string input, char separator)
        {
            List<string> strings = [];
            var current = new StringBuilder();

            foreach (char ch in input)
            {
                if (ch == separator)
                {
                    strings.Add(current.ToString());
                    current.Clear();
                    continue;
                }

                current.Append(ch);
            }

            strings.Add(current.ToString());

            return strings.ToArray();
        }

        public static string Trim(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            int start = 0;
            int end = input.Length - 1;

            while (start <= end && char.IsWhiteSpace(input[start]))
            {
                start++;
            }

            while (end >= start && char.IsWhiteSpace(input[end]))
            {
                end--;
            }

            return input[start..(end + 1)];
        }

        public static int WordCount(string input) => Split(input, ' ').Length;
    }
}
