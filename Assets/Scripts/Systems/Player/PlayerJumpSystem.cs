using UnityEngine;

public class PlayerJumpSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<EntityProvider>() == false ||
            Providers.Has<PlayerJumpProvider>() == false ||
            Providers.Has<PointCheckerProvider>() == false)
            return;

        Jump();
    }

    private void Jump()
    {
        ref var jumpComponent = ref Providers.Get<PlayerJumpProvider>().component;

        ref var jump = ref jumpComponent.jump;
        ref var jumpForce = ref jumpComponent.jumpForce;

        ref var entity = ref Providers.Get<EntityProvider>().component.entity;

        if (Input.GetKeyDown(jump))
        {
            if (IsGround())
            {
                if (entity.TryGetComponent(out Rigidbody2D rigidbody))
                {
                    rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                }
            }
        }
    }

    private bool IsGround()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        return pointCheckerComponent.isBottomCollide;
    }
}
