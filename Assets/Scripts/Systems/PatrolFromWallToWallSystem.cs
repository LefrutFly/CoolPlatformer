using UnityEngine;

public class PatrolFromWallToWallSystem : BaseSystem, IFixedUpdatableSystem
{
    private bool isLeft = true;

    public void FixedUpdate()
    {
        if (Providers.Has<MoveSpeedProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<PointCheckerProvider>() == false ||
            Providers.Has<ViewProvider>() == false)
            return;

        Patrol();
    }

    private void Patrol()
    {
        var pointChecker = Providers.Get<PointCheckerProvider>().component;

        if (pointChecker.isLeftCollide)
            isLeft = true;
        else if (pointChecker.isRightCollide)
            isLeft = false;

        if (isLeft)
        {
            StartMove(new Vector2(1, 0));
            LookAtAngle(0);
        }
        else
        {
            StartMove(new Vector2(-1, 0));
            LookAtAngle(180);
        }
    }

    private void StartMove(Vector2 direction)
    {
        var entity = Providers.Get<EntityProvider>().component.entity;
        var moveSpeed = Providers.Get<MoveSpeedProvider>().component.moveSpeed;

        Rigidbody2D rigidbody;
        if (entity.TryGetComponent(out Rigidbody2D rb))
        {
            rigidbody = rb;
        }
        else
        {
            Debug.Log($"There is no Rjidbody2D component on the {entity.gameObject.name}");
            return;
        }

        Vector3 v = rigidbody.velocity;

        if (direction.x != 0)
        {
            v.x = direction.x * moveSpeed * Time.deltaTime;
        }
        else if (direction.y != 0)
        {
            v.y = direction.y * moveSpeed * Time.deltaTime;
        }

        rigidbody.velocity = v;
    }

    private void LookAtAngle(float angle)
    {
        var view = Providers.Get<ViewProvider>().component.view;

        view.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}