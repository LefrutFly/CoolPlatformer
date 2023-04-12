using Lefrut.Framework;
using UnityEngine;

[System.Serializable]
public class FingerOfDeathVisionData : IData
{
    public Collider2D VisionArea1;
    public Collider2D VisionArea2;
    public bool IsPlayerInArea1 = false;
    public bool IsPlayerInArea2 = false;
}
