using Lefrut.Framework;
using UnityEngine;

public class PlayerJumpSystem : BaseSystem, IEnableSystem, IDisableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new PlayerJumpProvider(), this);
        NeededProviders.Set(new PointCheckerProvider(), this);
    }

    public void Enable()
    {
        if (IsActive == false) return;

        Player player = Facade as Player;

        player.inputs.Player.Jump.performed += context => Jump();
    }

    public void Disable()
    {
        if (IsActive == false) return;

        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<PlayerJumpProvider>() == false ||
            Providers.Has<PointCheckerProvider>() == false)
            return;

        Player player = Facade as Player;

        player.inputs.Player.Jump.performed -= context => Jump();
    }

    private void Jump()
    {
        ref var jumpComponent = ref Providers.Get<PlayerJumpProvider>().component;
        ref var jumpForce = ref jumpComponent.jumpForce;
        ref var entity = ref Providers.Get<EntityProvider>().component.entity;

        if (IsGround())
        {
            if (entity.TryGetComponent(out Rigidbody2D rigidbody))
            {
                rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private bool IsGround()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        return pointCheckerComponent.isBottomCollide;
    }
}
