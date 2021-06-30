using System.Collections.Generic;
using Ninject;

namespace VendingMachine
{
    internal interface IServiceLocator
    {
        T Get<T>();
    }

    internal class ServiceLocator
    {
        private static IServiceLocator serviceLocator;

        static ServiceLocator()
        {
            serviceLocator = new DefaultServiceLocator();
        }

        public static IServiceLocator Current
        {
            get { return serviceLocator; }
        }

        private sealed class DefaultServiceLocator : IServiceLocator
        {
            private readonly IKernel _kernel; // Ninject kernel

            public DefaultServiceLocator()
            {
                _kernel = new StandardKernel();
                LoadBindings();
            }

            public T Get<T>()
            {
                return _kernel.Get<T>();
            }

            private void LoadBindings()
            {
                _kernel.Bind<IVendingMachineInventory>().To<VMInventory>().InSingletonScope();
                _kernel.Bind<IVendingMachineWallet>().To<VMWallet>().InSingletonScope();
                _kernel.Bind<IVendingMachineInterface>().To<VMInterface>().InSingletonScope();
                _kernel.Bind<IVendingMachineLogger>().To<VMLogger>().InSingletonScope();
                /*_kernel.Bind<IDrink>().To<Drink>();
                _kernel.Bind<IFood>().To<Food>();
                _kernel.Bind<IWeapon>().To<Weapon>();*/
            }
        }
    }
}