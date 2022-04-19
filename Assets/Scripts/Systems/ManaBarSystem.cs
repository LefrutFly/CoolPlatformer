public class ManaBarSystem : BaseSystem, IStartableSystem, IDisableSystem
{
    public void Start()
    {
        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<ManaBarProvider>() == false)
            return;

        var entity = Providers.Get<EntityProvider>().component.entity;

        if (entity.Providers.TryGet(out ManaProvider manaProvider))
        {
            float mana = entity.Providers.Get<ManaProvider>().component.Mana;

            ChangeBar(mana);

            entity.Providers.Get<ManaProvider>().component.ChangedMana += () =>
            {
                float mana = entity.Providers.Get<ManaProvider>().component.Mana;

                ChangeBar(mana);
            };
        }
    }

    public void Disable()
    {
        if (Providers.Has<EntityProvider>() == false)
            return;

        var manaBarComponent = Providers.Get<ManaBarProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;

        if (entity.Providers.TryGet(out ManaProvider manaProvider))
        {
            entity.Providers.Get<ManaProvider>().component.ChangedMana -= () =>
            {
                float mana = entity.Providers.Get<ManaProvider>().component.Mana;

                ChangeBar(mana);
            };
        }
    }

    private void ChangeBar(float mana)
    {
        var manaBarComponent = Providers.Get<ManaBarProvider>().component;

        var text = manaBarComponent.text;
        var animator = manaBarComponent.animator;
        var nameAnimationTrigger = manaBarComponent.nameAnimationTrigger;

        text.text = "MP : " + mana;
        animator.SetTrigger(nameAnimationTrigger);
    }
}