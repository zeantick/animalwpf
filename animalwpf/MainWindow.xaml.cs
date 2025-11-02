using animalwpf.ViewModels;
using System.Windows;

namespace animalwpf
{
    public partial class MainWindow : Window
    {
        public MainViewModel VM { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            VM = new MainViewModel();
            DataContext = VM;
        }

        private void MakeSoundButton_Click(object sender, RoutedEventArgs e)
        {
            VM.MakeSound();
        }

        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            VM.Feed(FoodTextBox.Text);
            FoodTextBox.Clear();
        }

        private void CrazyActionButton_Click(object sender, RoutedEventArgs e)
        {
            VM.CrazyAction();
        }

        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            string input = NewAnimalTextBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                VM.AddLog("Please enter name and age in the format: Name,Age");
                return;
            }

            string[] parts = input.Split(',');
            if (parts.Length != 2 || !int.TryParse(parts[1].Trim(), out int age))
            {
                VM.AddLog("Invalid format. Use: Name,Age");
                return;
            }

            VM.AddAnimal(new Models.Cat { Name = parts[0].Trim(), Age = age });
            NewAnimalTextBox.Clear();
        }

        private void RemoveAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            VM.RemoveAnimal();
        }

        // Новый метод для кнопки Show Stats
        private void ShowStatsButton_Click(object sender, RoutedEventArgs e)
        {
            var stats = VM.GetStats();
            foreach (var s in stats)
            {
                VM.AddLog(s);
            }
        }
    }
}
