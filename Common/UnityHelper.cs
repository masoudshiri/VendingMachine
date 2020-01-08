using System;
using Unity;
using Unity.Lifetime;

namespace VendoreMachine.Common
{
     public static class UnityHelper
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        public static void Register<T>() 
        {
            UnityContainer.RegisterType<T>(new ContainerControlledLifetimeManager());
        }
        public static void Register(Type I, Type T) 
        {
            UnityContainer.RegisterType(I, T);
        }
        public static void InjectStub<I>(I instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
