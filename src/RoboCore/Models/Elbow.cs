namespace RoboCore.Models
{
    public class Elbow
    {
        private const int ContractIncrement = 1;

        public Elbow(Arm arm)
        {
            Arm = arm;
        }

        public Arm Arm { get; private set; }

        public ElbowState ElbowState { get; private set; }

        public void Contract()
        {
            ElbowState += ContractIncrement;
        }

        public void Relax()
        {
            ElbowState -= ContractIncrement;
        }
    }
}