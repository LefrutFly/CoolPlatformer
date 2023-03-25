using Lefrut.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Lefrut.Framework
{
    public class GlobalSystemStorage : DIExtension<GlobalSystemStorage>
    {
        private const int COUNT_SYSTEMS = 10000;


        public List<IEnableSystem>[] enableSystems { get; private set; } = new List<IEnableSystem>[COUNT_SYSTEMS];
        public List<IStartableSystem>[] startableSystems { get; private set; } = new List<IStartableSystem>[COUNT_SYSTEMS];
        public List<IUpdatableSystem>[] updatableSystems { get; private set; } = new List<IUpdatableSystem>[COUNT_SYSTEMS];
        public List<IFixedUpdatableSystem>[] fixedUpdatableSystems { get; private set; } = new List<IFixedUpdatableSystem>[COUNT_SYSTEMS];
        public List<ILateUpdatableSystem>[] lateUpdatableSystems { get; private set; } = new List<ILateUpdatableSystem>[COUNT_SYSTEMS];
        public List<ITriggerableSystem>[] triggerableSystems { get; private set; } = new List<ITriggerableSystem>[COUNT_SYSTEMS];
        public List<ICollidableSystem>[] collidableSystems { get; private set; } = new List<ICollidableSystem>[COUNT_SYSTEMS];
        public List<IDisableSystem>[] disableSystems { get; private set; } = new List<IDisableSystem>[COUNT_SYSTEMS];
        public List<IDestroySystem>[] destroySystems { get; private set; } = new List<IDestroySystem>[COUNT_SYSTEMS];
        public Property<BaseSystem>[] Systems => systems;


        private Property<BaseSystem>[] systems = new Property<BaseSystem>[COUNT_SYSTEMS * 9];
        private int lastIndex = -1;


        private void Awake()
        {
            InitArrays();
        }

        public int GetIndex()
        {
            if (lastIndex < COUNT_SYSTEMS)
            {
                lastIndex++;
            }
            else
            {
                Debug.LogError("!GlobalSystemStorage! StartablesSystems is full! Try increasing the COUNT_SYSTEMS value.");
            }

            return lastIndex;
        }

        public void AddEnableSystem(int index, IEnableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                enableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddStartableSystem(int index, IStartableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                startableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddUpdatableSystem(int index, IUpdatableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                updatableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddFixedUpdatableSystem(int index, IFixedUpdatableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                fixedUpdatableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddLateUpdatableSystem(int index, ILateUpdatableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                lateUpdatableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddTriggerableSystem(int index, ITriggerableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                triggerableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddCollidableSystem(int index, ICollidableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                collidableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddDisableSystem(int index, IDisableSystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                disableSystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void AddDestroySystem(int index, IDestroySystem system)
        {
            if (index < COUNT_SYSTEMS && index >= 0)
            {
                destroySystems[index].Add(system);
                systems[index].Set(system as BaseSystem);
            }
        }

        public void RemoveSystem(int index, BaseSystem system)
        {
            if (system is IEnableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (enableSystems[index].Contains(system as IEnableSystem))
                    {
                        enableSystems[index].Remove(system as IEnableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is IStartableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (startableSystems[index].Contains(system as IStartableSystem))
                    {
                        startableSystems[index].Remove(system as IStartableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is IUpdatableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (updatableSystems[index].Contains(system as IUpdatableSystem))
                    {
                        updatableSystems[index].Remove(system as IUpdatableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is IFixedUpdatableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (fixedUpdatableSystems[index].Contains(system as IFixedUpdatableSystem))
                    {
                        fixedUpdatableSystems[index].Remove(system as IFixedUpdatableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is ILateUpdatableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (lateUpdatableSystems[index].Contains(system as ILateUpdatableSystem))
                    {
                        lateUpdatableSystems[index].Remove(system as ILateUpdatableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is ITriggerableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (triggerableSystems[index].Contains(system as ITriggerableSystem))
                    {
                        triggerableSystems[index].Remove(system as ITriggerableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is ICollidableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (collidableSystems[index].Contains(system as ICollidableSystem))
                    {
                        collidableSystems[index].Remove(system as ICollidableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is IDisableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (disableSystems[index].Contains(system as IDisableSystem))
                    {
                        disableSystems[index].Remove(system as IDisableSystem);
                        systems[index].Delete(system);
                    }
                }
            }
            if (system is IDisableSystem)
            {
                if (index < COUNT_SYSTEMS && index >= 0)
                {
                    if (destroySystems[index].Contains(system as IDestroySystem))
                    {
                        destroySystems[index].Remove(system as IDestroySystem);
                        systems[index].Delete(system);
                    }
                }
            }
        }

        public BaseSystem FindSystem<T>(int index) where T : BaseSystem, new()
        {
            return systems[index].Get<T>();
        }

        private void InitArrays()
        {
            systems.InitArray();
            enableSystems.InitArray();
            startableSystems.InitArray();
            updatableSystems.InitArray();
            fixedUpdatableSystems.InitArray();
            lateUpdatableSystems.InitArray();
            triggerableSystems.InitArray();
            collidableSystems.InitArray();
            disableSystems.InitArray();
            destroySystems.InitArray();
        }
    }
}