using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lefrut.Framework
{
    public class Property<Y>
    {
        public const bool DEBUG_MODE = false;


        public Dictionary<Type, Y> Properties => properties;

        private Dictionary<Type, Y> properties = new Dictionary<Type, Y>();


        public Type[] GetKeyArray()
        {
            return properties.Keys.ToArray();
        }

        public Type[] GetKeyArray(object sender)
        {
            if (DEBUG_MODE)
                Debug.Log($"'{sender}' Requested Get Key Array");
            return properties.Keys.ToArray();
        }

        public Y[] GetValuesArray()
        {
            return properties.Values.ToArray();
        }

        public Y[] GetValuesArray(object sender)
        {
            if (DEBUG_MODE)
                Debug.Log($"'{sender}' Requested Get Values Array");
            return properties.Values.ToArray();
        }

        public List<Y> GetValuesList()
        {
            return properties.Values.ToList();
        }

        public List<Y> GetValuesList(object sender)
        {
            if (DEBUG_MODE)
                Debug.Log($"'{sender}' Requested Get Values List");

            return properties.Values.ToList();
        }

        public void AddPropertyElements(Property<Y> property)
        {
            var array = property.GetValuesArray();

            foreach (var element in array)
            {
                if (Has(element))
                {
                    continue;
                }
                else
                {
                    Set(element);
                }
            }
        }

        public void Set<T>(T property) where T : Y
        {
            var type = property.GetType();

            if (Has(property) == false)
            {
                properties[type] = property;

                if (DEBUG_MODE)
                    Debug.Log($"!SET! Property '{property}' has been added");
            }
            else
            {
                if (DEBUG_MODE)
                    Debug.LogError($"!SET! You are trying to add a property '{typeof(T)}' has already been added!");
            }
        }

        public void Set<T>(T property, object sender) where T : Y
        {
            var type = property.GetType();

            if (Has(property) == false)
            {
                properties[type] = property;

                if (DEBUG_MODE)
                    Debug.Log($"!SET! '{sender}' has been added '{property}' property");
            }
            else
            {
                if (DEBUG_MODE)
                    Debug.LogError($"!SET! You are trying to add a property '{typeof(T)}' has already been added!");
            }
        }

        public void SetOnlyNewProperties<T>(T property) where T : Y
        {
            var type = property.GetType();

            if (Has(property) == false)
            {
                properties[type] = property;
            }
        }

        public void TakeArrayBack(Y[] array)
        {
            if (array == null) return;

            foreach (var item in array)
            {
                Set(item);
            }
        }

        public void TakeListBack(List<Y> list)
        {
            if (list == null) return;

            foreach (var item in list)
            {
                Set(item);
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

        public bool Has<T>(T property) where T : Y
        {
            var type = property.GetType();

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
                if (DEBUG_MODE)
                    Debug.LogError($"Could not find object by key {typeof(T)}!");
                return new T();
            }
        }

        public T GetElseAdd<T>() where T : Y, new()
        {
            if (properties.ContainsKey(typeof(T)))
            {
                return (T)properties[typeof(T)];
            }
            else
            {
                var addedProperty = new T();
                Set(addedProperty);
                return Get<T>();
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

        public Property<Y> Clone()
        {
            var clone = new Property<Y>();

            Y[] propertiesArray = properties.Select(x => x.Value).ToArray();

            foreach (var element in propertiesArray)
            {
                clone.Set(element);
            }

            return clone;
        }

        public void Delete<T>()
        {
            if (properties.ContainsKey(typeof(T)))
            {
                properties.Remove(typeof(T));
            }
            else
            {
                if (DEBUG_MODE)
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
                if (DEBUG_MODE)
                    Debug.LogError($"Could not find object by key {typeof(T)}!");
            }
        }

        public void ClearAll()
        {
            properties.Clear();
        }
    }
}