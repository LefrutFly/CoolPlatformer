using UnityEngine;

namespace Lefrut.Framework
{
    public interface ITriggerableSystem
    {
        void TriggetEnter(Collider2D collision);
        void TriggetStay(Collider2D collision);
        void TriggetExit(Collider2D collision);
    }
}