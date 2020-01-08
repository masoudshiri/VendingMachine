using VendoreMachine.Common;
namespace VendoreMachine.Dto
{
    public abstract class BaseDTO : BaseNotifier
    {
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
    }
}
