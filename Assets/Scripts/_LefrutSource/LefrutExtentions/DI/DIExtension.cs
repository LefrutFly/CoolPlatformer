using UnityEngine;

namespace Lefrut.Extensions
{
    public abstract class DIExtension<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T currentInstance;


        public static T GetInstance()
        {
            if (currentInstance != null) return currentInstance;

            var allObjectsOfType = FindObjectsOfType<T>();
            var instancesLength = allObjectsOfType.Length;

            if (instancesLength > 0)
            {
                if (instancesLength > 1)
                {
                    for (var i = 1; i < instancesLength; i++)
                    {
                        Destroy(allObjectsOfType[i]);
                    }
                }

                currentInstance = allObjectsOfType[0];
                return currentInstance;
            }
            else
            {
                var obj = new GameObject("*", typeof(T));
                currentInstance = Instantiate(
                    obj, 
                    new Vector3(0, 0, 0), 
                    Quaternion.identity)
                    .GetComponent<T>();
                currentInstance.name = $"[DI] {typeof(T).Name}";
                Destroy(obj.gameObject);
                return currentInstance;
            }
        }
    }
}