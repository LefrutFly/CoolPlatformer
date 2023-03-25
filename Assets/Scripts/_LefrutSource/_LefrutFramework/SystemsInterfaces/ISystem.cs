using UnityEngine;

namespace Lefrut.Framework
{
    public interface ISystem
    {
        void Initialize(Property<MonoBehaviour> providers, Facade facade);
    }
}