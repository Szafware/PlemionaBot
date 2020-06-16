using System;

namespace Plemiona.DependencyInjection
{
    public interface IContainer
    {
        void Bind<TInterface, TImplementation>() where TImplementation : TInterface;
        void Bind<TInterface>(Type implementationType);

        void BindAsSingleton<TInterface, TImplementation>() where TImplementation : TInterface;
        void BindAsSingleton<TInterface>(Type implementationType);
        void BindToSelfAsSingleton<TClass>();

        void BindToSelf<TClass>() where TClass : class;

        TInterface GetImplementation<TInterface>();
    }
}