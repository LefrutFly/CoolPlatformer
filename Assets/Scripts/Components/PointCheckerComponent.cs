using UnityEngine;

[System.Serializable]
public class PointCheckerComponent
{
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform upPoint;
    public Transform downPoint;
    [Space]
    public Vector2 sizeColliderLeft;
    public Vector2 sizeColliderRight;
    public Vector2 sizeColliderUp;
    public Vector2 sizeColliderDown;
    [Space]
    public LayerMask layer;
    [Space]
    public bool isCollide;
    public bool isLeftCollide;
    public bool isRightCollide;
    public bool isTopCollide;
    public bool isBottomCollide;
}
