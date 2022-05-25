using System;
using System.Collections.Generic;
using UnityEngine;

public class Property<Y>
{
    private Dictionary<Type, Y> properties = new Dictionary<Type, Y>();

    public void Set<T>(T newProperty) where T : Y
    {
        var type = newProperty.GetType();

        if (properties.ContainsKey(type) == false)
        {
            properties[type] = newProperty;
        }
        else
        {
            Debug.LogError($"You are trying to add a property {typeof(T)} has already been added!");
        }
    }

    public bool Has<T>() where T : Y
    {
        if (properties.ContainsKey(typeof(T)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Has<T>(T newProperty) where T : Y
    {
        var type = newProperty.GetType();

        if (properties.ContainsKey(type))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public T Get<T>() where T : Y, new()
    {
        if (properties.ContainsKey(typeof(T)))
        {
            return (T)properties[typeof(T)];
        }
        else
        {
            Debug.LogError($"Could not find object by key {typeof(T)}!");
            return new T();
        }
    }

    public bool TryGet<T>(out T property) where T : Y, new()
    {
        if (properties.ContainsKey(typeof(T)))
        {
            property = (T)properties[typeof(T)];
            return true;
        }
        else
        {
            property = new T();
            return false;
        }
    }

    public void Delete<T>()
    {
        if (properties.ContainsKey(typeof(T)))
        {
            properties.Remove(typeof(T));
        }
        else
        {
            Debug.LogError($"Could not find object by key {typeof(T)}!");
        }
    }

    public void Delete<T>(T property)
    {
        var type = property.GetType();

        if (properties.ContainsKey(type))
        {
            properties.Remove(typeof(T));
        }
        else
        {
            Debug.LogError($"Could not find object by key {typeof(T)}!");
        }
    }

    public void ClearAll()
    {
        properties.Clear();
    }
}