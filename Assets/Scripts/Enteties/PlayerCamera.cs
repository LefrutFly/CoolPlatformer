using System.Collections;
using UnityEngine;

public class PlayerCamera : Entity
{
    protected override void Initialize()
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