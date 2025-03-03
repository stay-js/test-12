namespace AlakzatJatek_Lib
{
    public class ShapesGrid
    {
        public Shape[,] Shapes { get; }

        public int Size => Shapes.GetLength(0);
        
        public ShapesGrid() => Shapes = new Shape[0,0];

        public ShapesGrid(string input)
        {
            string[] lines = input.Split('\n');
            
            if (!int.TryParse(lines[0], out int size) || size < 3 || size > 6)
                throw new FormatException("A fájl formátuma érvénytelen.");
            
            Shapes = new Shape[size, size];
            lines = lines.Skip(1).ToArray();
            if (lines.Length != size) throw new FormatException("A sorok száma nem megfelelő.");

            for (int i = 0; i < size; i++)
            {
                string[] shapes = lines[i].Split(';');
                if (shapes.Length != size) throw new FormatException("A sorok hossza nem megfelelő.");

                for (int j = 0; j < size; j++)
                {
                    Shapes[i, j] = ShapeFactory.Create(shapes[j], i, j);
                }
            }
        }
        
        public int CountSameShapeOrColor(int row, int col)
        {
            var shape = Shapes[row, col];
            var shapes = Shapes.Cast<Shape>().ToList();

            return shapes
                .Where(x => x != shape)
                .Where(x => x.Row == row || x.Column == col)
                .Count(x => !x.IsDifferent(shape));
        }
    } 
}
