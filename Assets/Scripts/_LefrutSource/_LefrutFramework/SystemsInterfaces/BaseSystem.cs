namespace Lefrut.Framework
{
    public abstract class BaseSystem
    {
        protected Facade Facade;

        public bool IsActive = true;

        public Property<MonoProvider> NeededProviders = new Property<MonoProvider>();

        public Property<MonoProvider> Providers = new Property<MonoProvider>();


        public virtual void Initialize(Property<MonoProvider> providers, Facade facade)
        {
            Providers = providers;
            Facade = facade;
        }

        public abstract void AddProviders();
    }
}