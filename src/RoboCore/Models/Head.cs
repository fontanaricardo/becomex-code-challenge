namespace RoboCore.Models
{
    public class Head : Rotatable
    {
        private const int InclinationIncrement = 1;

        public InclinationState InclinationState { get; private set; }

        public void InclinationUp()
        {
            InclinationState += InclinationIncrement;
        }

        public void InclinationDown()
        {
            InclinationState -= InclinationIncrement;
        }
    }
}