using animalwpf.Models;
using animalwpf.Interfaces;

public class Fish : Animal, IFlyable
{
    public override string MakeSound() => "Blub blub!";
    public void Fly()
    {
    }
}
