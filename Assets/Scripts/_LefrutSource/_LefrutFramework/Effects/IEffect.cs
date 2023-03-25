using System;

namespace Lefrut.Framework
{
    public interface IEffect
    {
        void StartEffect(Facade entity, Action callback = null);
        void StopEffect(Action callback = null);
    }
}
