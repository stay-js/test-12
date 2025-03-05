namespace Torpek_Lib
{
    public class Torpe
    {
        public const int MIN_COUNT = 1;
        public const int MAX_COUNT = 1000;
        public const int MIN_DEPTH = 1;
        public const int MAX_DEPTH = 8;
    
        private List<int> _gnomes = [];
        private readonly List<int> _holes = [];
    
        public int GnomeCount() => _gnomes.Count;
        public int HoleCount() => _holes.Count;
    
        public void AddGnome() => _gnomes.Add(_gnomes.Count + 1);

        public void AddGnomes(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddGnome();
            }
        }

        public void AddHole(int depth)
        {
            if (depth < MIN_DEPTH)
                throw new HoleDepthException("Depth is too low.");
            if (depth > MAX_DEPTH)
                throw new HoleDepthException("Depth is too high.");
        
            _holes.Add(depth);
        }

        public List<int> FinalOrder()
        {
            if (GnomeCount() < MIN_COUNT)
                throw new GnomeCountException("Gnome Count is too low.");
        
            if (GnomeCount() > MAX_COUNT)
                throw new GnomeCountException("Gnome Count is too high.");

            if (HoleCount() < MIN_COUNT)
                throw new HoleCountException("Hole Count is too low.");
        
            if (HoleCount() > MAX_COUNT)
                throw new HoleCountException("Hole Count is too high.");

            foreach (var depth in _holes)
            {
                var hole = new Stack<int>();

                for (int i = 0; i < Math.Min(GnomeCount() + 1, depth); i++)
                {
                    hole.Push(_gnomes[0]);
                    _gnomes = _gnomes.Skip(1).ToList();
                }

                while (hole.Count > 0)
                {
                    int gnome = hole.Pop();
                    _gnomes.Add(gnome);
                }
            }

            return _gnomes;
        }
    }
}
