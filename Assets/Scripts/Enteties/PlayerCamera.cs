using Lefrut.Framework;
using System.Collections;
using UnityEngine;

public class PlayerCamera : Facade
{
    protected override void InitData()
    {
        AddData(new CameraFollowPlayer());
    }

    protected override void InitSystems()
    {
        StartCoroutine(GetLinks());

        AddSystem(new CameraFollowPlayer());
    }

    private IEnumerator GetLinks()
    {
        yield return null;

        if (Providers.TryGet(out CameraShiftProvider cameraShift))
        {
            if (cameraShift.component.target == null)
            {
                Transform player = GameLinks.GetLink<Player>().gameObject.transform;
                cameraShift.component.target = player;
            }
        }
    }
}