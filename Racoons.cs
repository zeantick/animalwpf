using animalwpf.Models;
using animalwpf.Interfaces;

public class Raccoon : Animal, ICrazyAction
{
    public override string MakeSound() => "Squeak!";
    public string ActCrazy() => $"{Name} found a shiny object!";
}
