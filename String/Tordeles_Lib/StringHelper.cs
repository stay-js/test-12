namespace Tordeles_Lib
{
    public static class StringHelper
    {
        public static string[] Split(string input, char separator)
        {
            List<string> strings = new();
            string current = "";
            
            foreach (char ch in input)
            {
                if (ch == separator)
                {
                    strings.Add(current);
                    current = "";
                    continue;
                }

                current += ch;
            }
            
            strings.Add(current);

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
            
            return input.Substring(start, end - start + 1);
        }

        public static int WordCount(string input)
        {
            return Split(input, ' ').Length;
        }
    }
}
