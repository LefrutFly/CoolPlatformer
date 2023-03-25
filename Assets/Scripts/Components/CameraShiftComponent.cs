using Lefrut.Framework;
using UnityEngine;

[System.Serializable]
public class CameraShiftComponent : IData
{
    public Transform target;
    public Vector3 shift;
}