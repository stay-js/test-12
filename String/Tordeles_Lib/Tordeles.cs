namespace Tordeles_Lib
{
    public static class Tordeles
    {
        public static string[] Tordel(string input, int length)
        {
            if (input.Length <= length) return [input];

            string[] words = StringHelper.Split(input, ' ');
            string current = "";

            List<string> result = [];

            foreach (string word in words)
            {
                if (word.Length > length)
                {
                    result.Add(current);
                    result.Add(word[..length]);
                    current = word[length..];

                    while (current.Length > length)
                    {
                        result.Add(current[..length]);
                        current = current[length..];
                    }

                    continue;
                }

                if (current.Length + word.Length > length)
                {
                    result.Add(current);
                    current = word;
                    continue;
                }

                current += current == "" ? word : $" {word}";
            }

            result.Add(current);

            return result.ToArray();
        }
    }
}
