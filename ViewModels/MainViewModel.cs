using VendoreMachine.Common;
using VendoreMachine.Domain;

namespace VendoreMachine.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        public MainViewModel()
        {
            CurrentViewModel = UnityHelper.Retrieve<ChooseViewModel>();
        }
        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        public User UserDataContext
        {
            get { return UnityHelper.Retrieve<User>(); }
        }
    }
}
