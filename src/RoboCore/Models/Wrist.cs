namespace RoboCore.Models
{
    public class Wrist : Rotatable
    {
        public Wrist(Arm arm)
        {
            Arm = arm;
        }

        public Arm Arm { get; private set; }
    }
}