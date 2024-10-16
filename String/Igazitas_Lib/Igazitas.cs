namespace Igazitas_Lib
{
    public enum Alignment
    {
        Left,
        Right,
        Middle
    }

    public class Igazitas(string str, int length, Alignment alignment)
    {
        public override string ToString()
        {
            if (str.Length == length) return str;


            int left, right;

            if (str.Length > length)
            {
                if (alignment == Alignment.Left) return str[..length];
                if (alignment == Alignment.Right) return str[^length..];

                left = (str.Length - length) / 2;
                right = str.Length - left;

                return str[left..right];
            }

            if (alignment == Alignment.Left)
            {
                return str + new string(' ', length - str.Length);
            }

            if (alignment == Alignment.Right)
            {
                return new string(' ', length - str.Length) + str;
            }

            left = (length - str.Length) / 2;
            right = length - str.Length - left;
            return new string(' ', left) + str + new string(' ', right);
        }
    }
}
