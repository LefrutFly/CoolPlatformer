using Lefrut.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeterminant
{
    public bool IsItT<T>(Collider2D collider, Facade thisEntity) where T : MonoBehaviour
    {
        List<Collider2D> colliders = new List<Collider2D>();

        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;

        collider.OverlapCollider(contactFilter, colliders);

        foreach (var c in colliders)
        {
            if (c.gameObject.GetComponent<T>() && c.gameObject != thisEntity.gameObject)
            {
                return true;
            }
        }
        return false;
    }
}