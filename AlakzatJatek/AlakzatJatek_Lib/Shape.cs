using System.Drawing;

namespace AlakzatJatek_Lib
{
    public class Shape(Shape.ShapeType type, Color color, int row, int column)
    {
        public readonly ShapeType Type = type;
        public readonly Color Color = color;
        
        public int Row { get; } = row;
        public int Column { get; } = column;
        
        public bool IsDifferent(Shape shape) => shape.Type != Type && shape.Color != Color;
        
        public enum ShapeType
        {
            Circle,
            Square1,
            Triangle1,
            Ellipse,
            Square2,
            Triangle2
        }
    }
}
