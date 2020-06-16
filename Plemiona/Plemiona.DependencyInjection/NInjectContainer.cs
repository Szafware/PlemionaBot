using Ninject;
using System;

namespace Plemiona.DependencyInjection
{
    public class NInjectContainer : IContainer
    {
        private readonly IKernel _kernel = new StandardKernel();

        public NInjectContainer()
        {
            _kernel.Bind<IContainer>().ToConstant(this).InSingletonScope();
        }

        public void Bind<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _kernel.Bind<TInterface>().To<TImplementation>();
        }

        public void Bind<TInterface>(Type implementationType)
        {
            _kernel.Bind<TInterface>().To(implementationType);
        }

        public void BindAsSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _kernel.Bind<TInterface>().To<TImplementation>().InSingletonScope();
        }

        public void BindAsSingleton<TInterface>(Type implementationType)
        {
            _kernel.Bind<TInterface>().To(implementationType).InSingletonScope();
        }

        public void BindToSelfAsSingleton<TClass>()
        {
            _kernel.Bind<TClass>().ToSelf().InSingletonScope();
        }

        public void BindToSelf<TClass>() where TClass : class
        {
            _kernel.Bind<TClass>().ToSelf();
        }

        public TInterface GetImplementation<TInterface>()
        {
            var implementation = _kernel.Get<TInterface>();

            return implementation;
        }
    }
}