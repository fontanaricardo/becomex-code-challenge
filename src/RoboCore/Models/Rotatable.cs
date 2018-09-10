namespace RoboCore.Models
{
    public abstract class Rotatable
    {
        private const int Increment = 45;

        public int Rotate { get; private set; } = 0;

        public void PlusRotate()
        {
            Rotate += Increment;
        }

        public void MinusRotate()
        {
            Rotate -= Increment;
        }
    }
}