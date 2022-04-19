public abstract class BaseSystem : ISystem
{
    public bool IsActive = true;

    public Property<MonoProvider> Providers = new Property<MonoProvider>();

    public virtual void Initialize(Property<MonoProvider> providers)
    {
        Providers = providers;
    }
}