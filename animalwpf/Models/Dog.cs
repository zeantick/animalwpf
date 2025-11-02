using animalwpf.Interfaces;
using System.Text;

namespace animalwpf.Models
{
    public class Dog : Animal, ICrazyAction
    {
        public override string MakeSound()
        {
            return "Woof!";
        }

        public string ActCrazy()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                result.Append("Woof! ");
            }
            return $"{Name} says: {result.ToString().Trim()}";
        }
    }
}
