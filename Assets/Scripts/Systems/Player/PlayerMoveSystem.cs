using Lefrut.Framework;
using UnityEngine;

public class PlayerMoveSystem : BaseSystem, IFixedUpdatableSystem
{
    public override void AddProviders()
    {
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new PlayerMoveProvider(), this);
        NeededProviders.Set(new ViewProvider(), this);
        NeededProviders.Set(new PointCheckerProvider(), this);
    }

    public void FixedUpdate()
    {
        if (IsActive == false) return;

        Player player = Facade as Player;
        PlayerInputs inputs = player.inputs;
        Vector2 direction = inputs.Player.Move.ReadValue<Vector2>();

        Move(direction);
    }

    private void StartMove(Vector2 direction)
    {
        var entity = Providers.Get<EntityProvider>().component.entity;
        var moveSpeed = Providers.Get<PlayerMoveProvider>().component.moveSpeed;
        var rigidbody = entity.GetComponent<Rigidbody2D>();
        var velocity = rigidbody.velocity;

        if (direction.x != 0)
        {
            velocity.x = direction.x * moveSpeed * Time.deltaTime;
        }
        else if (direction.y != 0)
        {
            velocity.y = direction.y * moveSpeed * Time.deltaTime;
        }

        rigidbody.velocity = velocity;
    }

    private void StopMove()
    {
        var entity = Providers.Get<EntityProvider>().component.entity;

        Rigidbody2D rigidbody = entity.GetComponent<Rigidbody2D>();
        Vector3 velocity = rigidbody.velocity;

        if (IsGroundDown())
        {
            velocity.x = 0;
        }
        else
        {
            rigidbody.AddForce(velocity * 0.1f);
        }

        rigidbody.velocity = velocity;
    }

    private bool IsGroundLeft()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        return pointCheckerComponent.isLeftCollide;
    }

    private bool IsGroundRight()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        return pointCheckerComponent.isRightCollide;
    }

    private bool IsGroundDown()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        return pointCheckerComponent.isBottomCollide;
    }

    private void LookAtAngle(float angle)
    {
        var view = Providers.Get<ViewProvider>().component.view;

        view.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    private void Move(Vector2 direction)
    {
        if (IsGroundLeft() == false && direction.x < 0)
        {
            StartMove(new Vector2(-1, 0));

            LookAtAngle(180);

            if (Providers.Has<DirectionProvider>())
            {
                Providers.Get<DirectionProvider>().component.direction = new Vector3(-1, 0, 0);
            }
        }
        else if (IsGroundRight() == false && direction.x > 0)
        {
            StartMove(new Vector2(1, 0));

            LookAtAngle(0);

            if (Providers.Has<DirectionProvider>())
            {
                Providers.Get<DirectionProvider>().component.direction = new Vector3(1, 0, 0);
            }
        }
        else
        {
            StopMove();
        }
    }
}
