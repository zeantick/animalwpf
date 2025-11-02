using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using animalwpf.Models;
using animalwpf.Interfaces;

namespace animalwpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Animal> Animals { get; set; }
        public ObservableCollection<string> Log { get; set; }

        private Animal selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                OnPropertyChanged("SelectedAnimal");
            }
        }

        // Вольер с Generics
        private Enclosure<Animal> enclosure;

        public MainViewModel()
        {
            Animals = new ObservableCollection<Animal>();
            Log = new ObservableCollection<string>();
            enclosure = new Enclosure<Animal>();

            // Инициализация животных
            Animals.Add(new Cat { Name = "Whiskers", Age = 2 });
            Animals.Add(new Dog { Name = "Buddy", Age = 3 });
            Animals.Add(new Bird { Name = "Tweety", Age = 1 });
            Animals.Add(new Raccoon { Name = "Rocky", Age = 2 });
            Animals.Add(new Monkey { Name = "George", Age = 3 });
            Animals.Add(new Fish { Name = "Nemo", Age = 1 });

            // Устанавливаем первое животное выбранным по умолчанию
            if (Animals.Count > 0)
                SelectedAnimal = Animals[0];

            // Подписка на события Enclosure
            enclosure.AnimalJoinedInSameEnclosure += Enclosure_AnimalJoined;
            enclosure.FoodDropped += Enclosure_FoodDropped;

            // Добавляем животных в вольер
            foreach (var animal in Animals)
                enclosure.AddAnimal(animal);

            // Запуск ночного события
            StartNightEvent();
        }

        private void Enclosure_AnimalJoined(Animal animal)
        {
            if (animal != null)
                AddLog(animal.Name + " joined the same enclosure!");
        }

        private void Enclosure_FoodDropped(Animal animal, string food)
        {
            if (animal != null)
                AddLog(animal.Name + " finished eating " + food);
        }

        public void AddLog(string message)
        {
            Log.Add(message);
        }

        private async void StartNightEvent()
        {
            while (true)
            {
                await Task.Delay(10000);
                AddLog("Night event: animals are doing crazy things!");
            }
        }

        //Методы для кнопок

        public void MakeSound()
        {
            if (SelectedAnimal != null)
                AddLog(SelectedAnimal.Name + " says: " + SelectedAnimal.MakeSound());
        }

        public void Feed(string food)
        {
            if (SelectedAnimal != null && !string.IsNullOrWhiteSpace(food))
                AddLog(SelectedAnimal.Name + " ate " + food);
        }

        public void CrazyAction()
        {
            if (SelectedAnimal is ICrazyAction)
                AddLog(((ICrazyAction)SelectedAnimal).ActCrazy());
            else if (SelectedAnimal != null)
                AddLog(SelectedAnimal.Name + " cannot do a crazy action.");
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            AddLog("Added " + animal.Name);
            enclosure.AddAnimal(animal);
        }

        public void RemoveAnimal()
        {
            if (SelectedAnimal != null)
            {
                AddLog("Removed " + SelectedAnimal.Name);
                Animals.Remove(SelectedAnimal);

                // После удаления выбираем другое животное (если есть)
                if (Animals.Count > 0)
                    SelectedAnimal = Animals[0];
                else
                    SelectedAnimal = null;
            }
        }

        // LINQ статистика
        public ObservableCollection<string> GetStats()
        {
            var stats = Animals
                .GroupBy(a => a.GetType().Name)
                .Select(g => g.Key + ": " + g.Count() + " animals, avg age " + g.Average(a => a.Age).ToString("F1"));

            return new ObservableCollection<string>(stats);
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
