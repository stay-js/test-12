namespace Tordeles_Lib
{
    public static class Tordeles
    {
        public static string[] Tordel(string input, int length)
        {
            if (input.Length <= length) return new []{input};

            string[] splitted = StringHelper.Split(input, ' ');
            string current = "";

            List<string> toReturn = new ();

            foreach (string word in splitted)
            {
                if (word.Length > length)
                {
                    toReturn.Add(current);
                    toReturn.Add(word[..length]);
                    current = word[length..];

                    while (current.Length > length)
                    {
                        toReturn.Add(current[..length]);
                        current = current[length..];
                    }
                    continue;
                }
                
                if (current.Length + word.Length > length)
                {
                    toReturn.Add(current);
                    current = word;
                    continue;
                }

                current += current == "" ? word : $" {word}";
            }
            
            toReturn.Add(current);

            return toReturn.ToArray();
        }
    }
}
