using Lefrut.Framework;
using UnityEngine;

[System.Serializable]
public class AnimaionDeathComponent : IData
{
    public GameObject prefab;
    public Transform spawnPoint;
    public float timerBeforeDelete;
}
