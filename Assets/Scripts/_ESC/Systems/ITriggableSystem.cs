using UnityEngine;

public interface ITriggableSystem
{
    void TriggetEnter(Collider2D collision);
    void TriggetStay(Collider2D collision);
    void TriggetExit(Collider2D collision);
}