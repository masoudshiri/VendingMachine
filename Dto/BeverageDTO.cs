namespace VendoreMachine.Dto
{
    public enum BeverageMakingState
    {
        InProgress,
        Compeleted,
        Canceled
    }
    public class BeverageDTO : BaseDTO
    {
        private BeverageMakingState state = BeverageMakingState.InProgress;
        private string name ;
        private string imageUrl;
        private byte stepIndex ;
        public string Name { get { return name; } set {   name = value; OnPropertyChanged("Name"); } }
        public string ImageUrl  { get { return imageUrl; } set { imageUrl = value; OnPropertyChanged("ImageUrl"); } }
        public byte StepIndex { get { return stepIndex; } set {  stepIndex = value; OnPropertyChanged("StepIndex"); } }
        public BeverageMakingState State { get { return state; } set {  state = value; OnPropertyChanged("State"); } }
    }
}
