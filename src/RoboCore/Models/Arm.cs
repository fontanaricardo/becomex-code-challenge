namespace RoboCore.Models
{
    public class Arm
    {
        public Arm()
        {
            Elbow = new Elbow(this);
            Wrist = new Wrist(this);
        }

        public Elbow Elbow { get; private set; }

        public Wrist Wrist { get; private set; }
    }
}