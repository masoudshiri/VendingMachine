using AutoMapper;
using System.Collections.ObjectModel;
using System.Linq;
using VendoreMachine.Common;
using VendoreMachine.Data;
using VendoreMachine.Domain;
using VendoreMachine.Dto;

namespace VendoreMachine.ViewModels
{
    public class ChooseViewModel : BaseViewModel
    {
        private readonly IMapper mapper;
        private ObservableCollection<BeverageDTO> beverageItems;
        public ChooseViewModel(IRepository<Beverage> repository, IMapper mapper)
        {
            this.mapper = mapper;
            repository.GetAll()
                .ContinueWith(x => BeverageItems = new ObservableCollection<BeverageDTO>(x.Result
                .Select(step => mapper.Map<BeverageDTO>(step))));
            ShowDetailCommand = new RelayCommand(param => GoToOrderDetail(param), () => true);
        }
        public RelayCommand ShowDetailCommand { get; set; }
        public ObservableCollection<BeverageDTO> BeverageItems
        {
            get
            {
                return beverageItems;
            }
            set
            {
                beverageItems = value;
                OnPropertyChanged("BeverageItems");
            }
        }
        private void GoToOrderDetail(object beverage)
        {
            MainViewModel mainVm = UnityHelper.Retrieve<MainViewModel>();
            OrderViewModel orderVm = UnityHelper.Retrieve<OrderViewModel>();
            orderVm.BeverageItem = (BeverageDTO)beverage;
            BeverageMakingStepRepository bmsRepository = (BeverageMakingStepRepository)UnityHelper
                .Retrieve<IBeverageMakingStepRepository>();
            bmsRepository.GetByBeverageId(orderVm.BeverageItem.Id)
                .ContinueWith(x =>
                {
                    orderVm.BeverageSteps = new ObservableCollection<BeverageMakingStepDTO>(x.Result
                        .Select(step => mapper.Map<BeverageMakingStepDTO>(step))
                        .OrderBy(stepDto=> stepDto.StepIndex));
                    orderVm.StartMaking(UnityHelper.Retrieve<ProccessBuilder>());
                });
            mainVm.CurrentViewModel = orderVm;
        }
    }
}
