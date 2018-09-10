namespace RoboCore.Models
{
    public class Robot
    {
        public Robot()
        {
            Head = new Head();
            RightArm = new Arm();
            LeftArm = new Arm();
        }

        public Head Head { get; private set; }

        public Arm RightArm { get; private set; }

        public Arm LeftArm { get; private set; }
    }
}