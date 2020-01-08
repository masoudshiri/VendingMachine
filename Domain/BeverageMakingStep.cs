namespace VendoreMachine.Domain
{
    public class BeverageMakingStep :EntityBase
    {
        public string Name { get; set; }
        public int BeverageId { get; set; }
        public byte StepIndex { get; set; }
    }
}
