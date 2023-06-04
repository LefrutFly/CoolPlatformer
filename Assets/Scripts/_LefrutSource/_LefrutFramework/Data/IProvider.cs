using NaughtyAttributes;
using UnityEngine;

namespace Lefrut.Framework
{
    public abstract class IProvider : MonoBehaviour 
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