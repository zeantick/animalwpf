using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using animalwpf.Models;

namespace animalwpf.Models
{
    public class Enclosure<T> where T : Animal
    {
        private List<T> animals = new List<T>();

        // События
        public event Action<T> AnimalJoinedInSameEnclosure;
        public event Action<T, string> FoodDropped;

        // Добавление животного
        public void AddAnimal(T animal)
        {
            animals.Add(animal);
            if (AnimalJoinedInSameEnclosure != null)
                AnimalJoinedInSameEnclosure(animal);
        }

        // Кормление с разной задержкой
        public async Task FeedAnimal(T animal, string food)
        {
            await Task.Delay(new Random().Next(500, 2000)); // разное время еды
            if (FoodDropped != null)
                FoodDropped(animal, food);
        }

        public IEnumerable<T> GetAllAnimals()
        {
            return animals;
        }
    }
}
