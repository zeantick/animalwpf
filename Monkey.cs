using animalwpf.Models;
using animalwpf.Interfaces;

public class Monkey : Animal, ICrazyAction
{
    public override string MakeSound() => "Ooh ooh aah aah!";
    public string ActCrazy() => $"{Name} swapped names with another animal!";
}
