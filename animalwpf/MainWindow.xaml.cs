using animalwpf.Models;
using animalwpf.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace animalwpf
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Animal> animals = new ObservableCollection<Animal>();

        public MainWindow()
        {
            InitializeComponent();
            AnimalsListBox.ItemsSource = animals;

            animals.Add(new Cat { Name = "Whiskers", Age = 2 });
            animals.Add(new Dog { Name = "Buddy", Age = 3 });
            animals.Add(new Bird { Name = "Tweety", Age = 1 });

            AnimalsListBox.SelectionChanged += AnimalsListBox_SelectionChanged;
        }

        private void AnimalsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selected)
            {
                NameText.Text = selected.Name;
                AgeText.Text = selected.Age.ToString();
            }
            else
            {
                NameText.Text = "";
                AgeText.Text = "";
            }
        }

        private void MakeSoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selected)
            {
                string sound = selected.MakeSound();
                LogListBox.Items.Add($"{selected.Name} says: {sound}");
            }
        }

        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selected && !string.IsNullOrWhiteSpace(FoodTextBox.Text))
            {
                LogListBox.Items.Add($"{selected.Name} ate {FoodTextBox.Text}");
                FoodTextBox.Clear();
            }
        }

        private void CrazyActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selected)
            {
                if (selected is ICrazyAction crazyAnimal)
                {
                    string actionLog = crazyAnimal.ActCrazy();
                    LogListBox.Items.Add(actionLog);
                }
                else
                {
                    LogListBox.Items.Add($"{selected.Name} cannot do a crazy action.");
                }
            }
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            string input = NewAnimalTextBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                LogListBox.Items.Add("Please enter name and age in the format: Name,Age");
                return;
            }

            string[] parts = input.Split(',');
            if (parts.Length != 2)
            {
                LogListBox.Items.Add("Invalid format. Use: Name,Age");
                return;
            }

            string name = parts[0].Trim();

            if (!int.TryParse(parts[1].Trim(), out int age))
            {
                LogListBox.Items.Add("Invalid age. Please enter a number after the comma.");
                return;
            }

            Cat newCat = new Cat { Name = name, Age = age };
            animals.Add(newCat);

            LogListBox.Items.Add($"Added new cat: {name}, Age: {age}");
            NewAnimalTextBox.Clear();
        }

        private void RemoveAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnimalsListBox.SelectedItem is Animal selected)
            {
                animals.Remove(selected);
            }
        }
    }
}
