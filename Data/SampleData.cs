using System.Collections.Generic;
using VendoreMachine.Domain;

namespace VendoreMachine.Data
{
    public class BeverageDbSet : ISampleData<Beverage>
    {
        public IEnumerable<Beverage> DbSet =>
                new Beverage[] { new Beverage { Id = 1, Name = "Hot Chocolate", ImageUrl = "pack://application:,,,/Resources/hot_chocolate.jpg" } ,
                                  new Beverage {Id=2,Name="Iced Coffee",ImageUrl="pack://application:,,,/Resources/iced_coffee.jpg" },
                                  new Beverage {Id=3,Name="Lemon Tea",ImageUrl="pack://application:,,,/Resources/lemon_tea.jpg" },
                                  new Beverage {Id=4,Name="White Coffee with 1 sugar",ImageUrl="pack://application:,,,/Resources/white_coffee.jpg" }
                };
    }


    public class BeverageMakingStepDbSet : ISampleData<BeverageMakingStep>
    {
        public IEnumerable<BeverageMakingStep> DbSet =>
            new BeverageMakingStep[] { new BeverageMakingStep {Id=1,BeverageId=1,Name="Boil water",StepIndex=0 },
                 new BeverageMakingStep {Id=2,BeverageId=1,Name="Add drinking chocolate to cup",StepIndex=1},
                 new BeverageMakingStep {Id=3,BeverageId=1,Name="Add water",StepIndex=2},

                 new BeverageMakingStep {Id=4,BeverageId=4,Name="Boil water",StepIndex=0},
                 new BeverageMakingStep {Id=5,BeverageId=4,Name="Add sugar",StepIndex=1},
                 new BeverageMakingStep {Id=6,BeverageId=4,Name="Add coffee granules to cup",StepIndex=2},
                 new BeverageMakingStep {Id=7,BeverageId=4,Name="Add water",StepIndex=3},
                 new BeverageMakingStep {Id=8,BeverageId=4,Name="Add milk",StepIndex=4},

                 new BeverageMakingStep {Id=9,BeverageId=3,Name="Boil water",StepIndex=0},
                 new BeverageMakingStep {Id=10,BeverageId=3,Name="Add water",StepIndex=1},
                 new BeverageMakingStep {Id=11,BeverageId=3,Name="Steep tea bag in hot water",StepIndex=2},
                 new BeverageMakingStep {Id=12,BeverageId=3,Name="Add lemon",StepIndex=3},

                 new BeverageMakingStep {Id=13,BeverageId=2,Name="Crush Ice",StepIndex=0},
                 new BeverageMakingStep {Id=14,BeverageId=2,Name="Add ice to blender",StepIndex=1},
                 new BeverageMakingStep {Id=15,BeverageId=2,Name="Add coffee syrup to blender",StepIndex=2},
                 new BeverageMakingStep {Id=16,BeverageId=2,Name="Blend ingredients",StepIndex=3},
                 new BeverageMakingStep {Id=17,BeverageId=2,Name="Add ingredients",StepIndex=4}

            };
    }
}
