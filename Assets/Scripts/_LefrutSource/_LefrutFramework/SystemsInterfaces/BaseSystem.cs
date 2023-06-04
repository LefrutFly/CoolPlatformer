namespace Lefrut.Framework
{
    public abstract class BaseSystem
    {
        protected Facade Facade;

        public bool IsActive = true;

        public Property<IProvider> NeededProviders = new Property<IProvider>();

        public Property<IProvider> Providers = new Property<IProvider>();


        public virtual void Initialize(Property<IProvider> providers, Facade facade)
        {
            Providers = providers;
            Facade = facade;
        }

        public abstract void AddProviders();
    }
}