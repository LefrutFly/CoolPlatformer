using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-999999999)]
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
        for (int i = 0; i < updatables.Count; i++)
        {
            if(updatables[i] != null)
            {
                updatables[i].Update();
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < fixedUpdatables.Count; i++)
        {
            if (fixedUpdatables[i] != null)
            {
                fixedUpdatables[i].FixedUpdate();
            }
        }
    }
}