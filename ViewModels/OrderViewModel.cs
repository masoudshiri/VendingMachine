using System.Collections.ObjectModel;
using System.Threading;
using VendoreMachine.Common;
using VendoreMachine.Dto;

namespace VendoreMachine.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private IProccessBuilder beverageBuilder;
        private BeverageDTO beverageItem;
        private ObservableCollection<BeverageMakingStepDTO> beverageSteps;
        public OrderViewModel()
        {
            OrderCommand = new RelayCommand(param => CancelOrder(), () => true);
            BackCommand = new RelayCommand(param => BackToMain(), () => BeverageItem.State != BeverageMakingState.InProgress);
        }
        public RelayCommand OrderCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public BeverageDTO BeverageItem
        {
            get
            {
                return beverageItem;
            }
            set
            {
                beverageItem = value;
                OnPropertyChanged("BeverageItem");
            }
        }
        public ObservableCollection<BeverageMakingStepDTO> BeverageSteps
        {
            get
            {
                return beverageSteps;
            }
            set
            {
                beverageSteps = value;
                OnPropertyChanged("BeverageSteps");
            }
        }
        internal void StartMaking(ProccessBuilder proccessBuilder)
        {
            foreach (BeverageMakingStepDTO step in beverageSteps)
            {
                proccessBuilder.AddToProccess(() =>
                {
                    Thread.Sleep(10000);
                    return true;
                });

            }
            beverageBuilder = proccessBuilder.GetBuilder();
            beverageBuilder.StepStarted += Builder_StepStarted; ;
            beverageBuilder.StepFinished += BeverageBuilder_StepFinished;
            beverageBuilder.Complished += BeverageBuilder_Complished;
            beverageBuilder.Execute(true);

        }
        private void CancelOrder()
        {
            if (BeverageItem.State == BeverageMakingState.InProgress)
            {
                beverageBuilder.StopExecuting((int)BeverageItem.State);
                BeverageItem.State = BeverageMakingState.Canceled;
            }
        }
        private void BackToMain()
        {
            MainViewModel mainVm = UnityHelper.Retrieve<MainViewModel>();
            ChooseViewModel ChooseVm = UnityHelper.Retrieve<ChooseViewModel>();
            mainVm.CurrentViewModel = ChooseVm;
        }
        private void Builder_StepStarted(int obj)
        {
            BeverageSteps[obj].State = BeverageMakingStepState.InProccess;
        }
        private void BeverageBuilder_Complished(bool obj)
        {
            BeverageItem.State = BeverageMakingState.Compeleted;
        }
        private void BeverageBuilder_StepFinished(int obj)
        {
            BeverageSteps[obj].State = BeverageMakingStepState.Finished;
        }
    }
}
