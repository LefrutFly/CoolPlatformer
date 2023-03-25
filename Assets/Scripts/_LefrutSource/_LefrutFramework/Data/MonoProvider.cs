using NaughtyAttributes;
using UnityEngine;

namespace Lefrut.Framework
{
    public abstract class MonoProvider : MonoBehaviour 
    {
        public abstract IData Data { get; }

        [HideInInspector] public Facade Facade;

        [Button] 
        public void Delete()
        {
            Facade?.MonoProvidersOnFacade.Remove(this);
            DestroyImmediate(this);
        }
    }
}