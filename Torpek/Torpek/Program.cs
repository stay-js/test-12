using Torpek_Lib;

var torpek = new Torpe();

int gnomeCount = 0;

while (gnomeCount is < Torpe.MIN_COUNT or > Torpe.MAX_COUNT)
{
    Console.Write("Hány törpe megy át az erdőn? ");
    bool _ = int.TryParse(Console.ReadLine() ?? "", out gnomeCount);
}

torpek.AddGnomes(gnomeCount);

int holeCount = 0;

while (holeCount is < Torpe.MIN_COUNT or > Torpe.MAX_COUNT)
{
    Console.Write("Hány gödör van az útjuk során? ");
    bool _ = int.TryParse(Console.ReadLine() ?? "", out holeCount);
}

for (int i = 0; i < holeCount; i++)
{
    int depth = 0;

    while (depth is < Torpe.MIN_DEPTH or > Torpe.MAX_DEPTH)
    {
        Console.Write($"A(z) {i + 1}. gödör milyen mély? ");
        bool _ = int.TryParse(Console.ReadLine() ?? "", out depth);
    }
    
    torpek.AddHole(depth);
}

Console.WriteLine("A törpék a következő sorrendben jöttek ki az erdőből: " +
    string.Join(", ", torpek.FinalOrder()));
    