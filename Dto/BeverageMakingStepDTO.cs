namespace VendoreMachine.Dto
{
    public enum BeverageMakingStepState
    {
        NotStarted,
        InProccess,
        Finished
    }
    public class BeverageMakingStepDTO : BaseDTO
    {
        private BeverageMakingStepState state = BeverageMakingStepState.NotStarted;
        private string name ;
        private int beverageId ;
        private byte stepIndex ;
        public string Name { get { return name; } set {   name = value; OnPropertyChanged("Name"); } }
        public int BeverageId { get { return beverageId; } set {  beverageId = value; OnPropertyChanged("BeverageId"); } }
        public byte StepIndex { get { return stepIndex; } set {  stepIndex = value; OnPropertyChanged("StepIndex"); } }
        public BeverageMakingStepState State { get { return state; } set {  state = value; OnPropertyChanged("State"); } }
    }
}
