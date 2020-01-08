namespace VendoreMachine.Domain
{
    public class User :EntityBase
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
