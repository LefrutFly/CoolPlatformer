using UnityEngine;

public class PointCheckerSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (Providers.Has<PointCheckerProvider>() == false) return;

        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var left = IsLeft();
        var right = IsRight();
        var bottom = IsBottom();
        var top = IsTop();
        var isInternal = IsInternal();

        pointCheckerComponent.isLeftCollide = left;
        pointCheckerComponent.isRightCollide = right;
        pointCheckerComponent.isBottomCollide = bottom;
        pointCheckerComponent.isTopCollide = top;
        pointCheckerComponent.isInternalCollide = isInternal;

        if (left == true || right == true || bottom == true || top == true || isInternal)
            pointCheckerComponent.isCollide = true;
        else
            pointCheckerComponent.isCollide = false;
    }

    private bool IsLeft()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var transform = pointCheckerComponent.leftPoint;
        var sizeCollider = pointCheckerComponent.sizeColliderLeft;
        var layer = pointCheckerComponent.layer;

        if(transform != null)
            return Physics2D.OverlapBox(transform.position, sizeCollider, 0, layer);
        else
            return false;
    }

    private bool IsRight()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var transform = pointCheckerComponent.rightPoint;
        var sizeCollider = pointCheckerComponent.sizeColliderRight;
        var layer = pointCheckerComponent.layer;

        if (transform != null)
            return Physics2D.OverlapBox(transform.position, sizeCollider, 0, layer);
        else
            return false;
    }

    private bool IsTop()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var transform = pointCheckerComponent.upPoint;
        var sizeCollider = pointCheckerComponent.sizeColliderUp;
        var layer = pointCheckerComponent.layer;

        if (transform != null)
            return Physics2D.OverlapBox(transform.position, sizeCollider, 0, layer);
        else
            return false;
    }

    private bool IsBottom()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var transform = pointCheckerComponent.downPoint;
        var sizeCollider = pointCheckerComponent.sizeColliderDown;
        var layer = pointCheckerComponent.layer;

        if (transform != null)
            return Physics2D.OverlapBox(transform.position, sizeCollider, 0, layer);
        else
            return false;
    }

    private bool IsInternal()
    {
        var pointCheckerComponent = Providers.Get<PointCheckerProvider>().component;

        var transform = pointCheckerComponent.internalPoint;
        var sizeCollider = pointCheckerComponent.sizeColliderInternal;
        var layer = pointCheckerComponent.layer;

        if (transform != null)
            return Physics2D.OverlapBox(transform.position, sizeCollider, 0, layer);
        else
            return false;
    }
}
