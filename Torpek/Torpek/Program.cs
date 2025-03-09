using Torpek_Lib;

var torpek = new Torpe();

int gnomeCount = GetValidInput("Hány törpe megy át az erdőn?",
    Torpe.MIN_COUNT,
    Torpe.MAX_COUNT);

torpek.AddGnomes(gnomeCount);

int holeCount = GetValidInput("Hány gödör van az útjuk során?",
    Torpe.MIN_COUNT,
    Torpe.MAX_COUNT);

for (int i = 0; i < holeCount; i++)
{
    int depth = GetValidInput($"A(z) {i + 1}. gödör milyen mély?",
        Torpe.MIN_DEPTH,
        Torpe.MAX_DEPTH);

    torpek.AddHole(depth);
}

Console.WriteLine("A törpék a következő sorrendben jöttek ki az erdőből: " +
    string.Join(", ", torpek.FinalOrder()));

static int GetValidInput(string prompt, int min, int max)
{
    int value;

    do Console.Write($"{prompt} ");
    while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);

    return value;
}
