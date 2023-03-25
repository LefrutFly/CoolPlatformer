using UnityEngine;

namespace Lefrut.Extensions
{
    public class EntityUpdatesAdder : MonoBehaviour
    {
        private GlobalUpdater updater;
        private IRun entity;

        private void Awake()
        {
            updater = GlobalUpdater.GetInstance();
            entity = GetComponent<IRun>();
        }

        private void OnEnable()
        {
            Add();
        }

        private void OnDisable()
        {
            Remove();
        }

        private void Add()
        {
            updater.AddUpdates(entity);
        }

        private void Remove()
        {
            updater.RemoveUpdates(entity);
        }
    }
}