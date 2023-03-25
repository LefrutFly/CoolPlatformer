using UnityEngine;

namespace Lefrut.Framework
{
    public interface ICollidableSystem
    {
        void CollideEnter(Collision2D collision);
        void CollideStay(Collision2D collision);
        void CollideExit(Collision2D collision);
    }
}