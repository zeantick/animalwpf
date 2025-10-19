using animalwpf.Interfaces;

namespace animalwpf.Models
{
    public class Bird : Animal, IFlyable, ICrazyAction
    {
        public bool IsFlying { get; private set; } = false;

        public override string MakeSound()
        {
            return "Chirp!";
        }

        public void Fly()
        {
            IsFlying = !IsFlying;
        }

        public string ActCrazy()
        {
            Fly();
            string flyingStatus = IsFlying ? "flying" : "landed";
            return $"{Name} is {flyingStatus} and screams CHIRP!!!";
        }
    }
}
