using animalwpf.Interfaces;

namespace animalwpf.Models
{
    public class Cat : Animal, ICrazyAction
    {
        public override string MakeSound()
        {
            return "Meow!";
        }

        public string ActCrazy()
        {
            return $"{Name} stole cheese from the kitchen!";
        }
    }
}
