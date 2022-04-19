using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    public static Updater instance;

    public List<IUpdatableSystem> updatables = new List<IUpdatableSystem>();
    public List<IFixedUpdatableSystem> fixedUpdatables = new List<IFixedUpdatableSystem>();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        foreach (var system in updatables)
        {
            system.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var system in fixedUpdatables)
        {
            system.FixedUpdate();
        }
    }
}