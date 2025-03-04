using System.Drawing;

namespace AlakzatJatek_Lib
{
    public static class ShapeFactory
    {
        // 2. feladat miatt használtam dictionary-t switch helyett
        private static readonly Dictionary<string, Color> ColorMap = new()
        {
            { "piros", Color.Red },
            { "zöld", Color.Green },
            { "sárga", Color.Yellow },
            { "kék", Color.Blue },
            { "lila", Color.Purple },
            { "narancs", Color.Orange }
        };

        public static Color ParseColor(string color) =>
            ColorMap.TryGetValue(color.Trim(), out var c)
                ? c
                : throw new ArgumentException("Nem megfelelő szín");

        public static Shape.ShapeType ParseShape(string shape)
        {
            return shape.Trim() switch
            {
                "kör" => Shape.ShapeType.Circle,
                "négyzet1" => Shape.ShapeType.Square1,
                "háromszög1" => Shape.ShapeType.Triangle1,
                "ellipszis" => Shape.ShapeType.Ellipse,
                "négyzet2" => Shape.ShapeType.Square2,
                "háromszög2" => Shape.ShapeType.Triangle2,
                _ => throw new ArgumentException("Nem megfelelő alak")
            };
        }

        public static Shape Create(string input, int row, int column)
        {
            string[] parts = input.Split('-');
            if (parts.Length != 2) throw new FormatException("Hibás formátum");
            return new Shape(ParseShape(parts[1]), ParseColor(parts[0]), row, column);
        }
    }
}
