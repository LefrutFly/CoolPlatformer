public abstract class BaseSystem : ISystem
{
    protected Entity Actor;

    public bool IsActive = true;

    public Property<MonoProvider> Providers = new Property<MonoProvider>();

    public virtual void Initialize(Property<MonoProvider> providers, Entity actor)
    {
        Providers = providers;
        Actor = actor;
    }
}