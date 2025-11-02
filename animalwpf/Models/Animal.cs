namespace animalwpf.Models
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string Describe()
        {
            return $"Name: {Name}, Age: {Age}";
        }

        public abstract string MakeSound();
    }
}
