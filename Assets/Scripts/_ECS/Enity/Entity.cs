using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected List<MonoProvider> providersList = new List<MonoProvider>();

    private Property<BaseSystem> systems = new Property<BaseSystem>();
    private Property<MonoProvider> providers = new Property<MonoProvider>();

    private List<IEnableSystem> enables = new List<IEnableSystem>();
    private List<IStartableSystem> startables = new List<IStartableSystem>();
    private List<IUpdatableSystem> updatables = new List<IUpdatableSystem>();
    private List<IFixedUpdatableSystem> fixedUpdatables = new List<IFixedUpdatableSystem>();
    private List<ITriggableSystem> triggables = new List<ITriggableSystem>();
    private List<IDisableSystem> disables = new List<IDisableSystem>();
    private List<IDestroySystem> destroys = new List<IDestroySystem>();

    public Property<BaseSystem> Systems => systems;
    public Property<MonoProvider> Providers => providers;

    public event Action DisableEvent;

    protected virtual void Awake()
    {
        foreach (var component in providersList)
        {
            providers.Set(component);
        }

        Initialize();
    }

    protected virtual void OnEnable()
    {
        foreach (var system in enables)
        {
            system.Enable();
        }

        AddUpdates();
    }

    protected virtual void Start()
    {
        foreach (var system in startables)
        {
            system.Start();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var system in triggables)
        {
            system.TriggetEnter(collision);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        foreach (var system in triggables)
        {
            system.TriggetStay(collision);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var system in triggables)
        {
            system.TriggetExit(collision);
        }
    }

    protected virtual void OnDisable()
    {
        foreach (var system in disables)
        {
            system.Disable();
        }

        DisableEvent?.Invoke();
        DisableEvent = null;

        ClearAllUpdates();
    }

    protected virtual void OnDestroy()
    {
        foreach (var system in destroys)
        {
            system.Destroy();
        }

        ClearAllUpdates();
    }

    public void OnSystem<T>() where T : BaseSystem, new()
    {
        T system = new T();

        if (systems.Has(system))
        {
            systems.Get<T>().IsActive = true;
        }
        else
        {
            Debug.LogError($"System not found in object {gameObject.name}");
        }
    }

    public void OffSystem<T>() where T : BaseSystem, new()
    {
        T system = new T();

        if (systems.Has(system))
        {
            systems.Get<T>().IsActive = false;
        }
        else
        {
            Debug.LogError($"System not found in object {gameObject.name}");
        }
    }

    public void AddSystem(BaseSystem system)
    {
        if (system == null) return;

        system.Initialize(providers, this);

        if (systems.Has(system))
        {
            systems.Delete(system);
        }

        systems.Set(system);

        if (system is IEnableSystem)
        {
            enables.Add(system as IEnableSystem);
        }
        if (system is IStartableSystem)
        {
            startables.Add(system as IStartableSystem);
        }
        if (system is IUpdatableSystem)
        {
            updatables.Add(system as IUpdatableSystem);
        }
        if (system is IFixedUpdatableSystem)
        {
            fixedUpdatables.Add(system as IFixedUpdatableSystem);
        }
        if (system is ITriggableSystem)
        {
            triggables.Add(system as ITriggableSystem);
        }
        if (system is IDisableSystem)
        {
            disables.Add(system as IDisableSystem);
        }
        if(system is IDestroySystem)
        {
            destroys.Add(system as IDestroySystem);
        }
        if (system is IRunOnAddSystem)
        {
            (system as IRunOnAddSystem).RunOnAdd();
            systems.Delete(system);
        }
    }

    public void DeleteSystem<T>() where T : BaseSystem, new()
    {
        systems.Delete<T>();

        T del = new T();

        if (del is IEnableSystem)
        {
            foreach (var system in enables)
            {
                if (system is T)
                {
                    enables.Remove(system);
                    return;
                }
            }
        }
        if (del is IStartableSystem)
        {
            foreach (var system in startables)
            {
                if (system is T)
                {
                    startables.Remove(system);
                    return;
                }
            }
        }
        if (del is IUpdatableSystem)
        {
            foreach (var system in updatables)
            {
                if (system is T)
                {
                    updatables.Remove(system);
                    Updater.instance.updatables.Remove(system);
                    return;
                }
            }
        }
        if (del is IFixedUpdatableSystem)
        {
            foreach (var system in fixedUpdatables)
            {
                if (system is T)
                {
                    fixedUpdatables.Remove(system);
                    Updater.instance.fixedUpdatables.Remove(system);
                    return;
                }
            }
        }
        if (del is ITriggableSystem)
        {
            foreach (var system in triggables)
            {
                if (system is T)
                {
                    triggables.Remove(system);
                    return;
                }
            }
        }
        if (del is IDisableSystem)
        {
            foreach (var system in disables)
            {
                if (system is T)
                {
                    disables.Remove(system);
                    return;
                }
            }
        }
        if (del is IDestroySystem)
        {
            foreach (var system in destroys)
            {
                if (system is T)
                {
                    destroys.Remove(system);
                    return;
                }
            }
        }
    }

    private void AddUpdates()
    {
        ClearAllUpdates();
        Updater.instance.updatables.AddRange(updatables);
        Updater.instance.fixedUpdatables.AddRange(fixedUpdatables);
    }

    private void AddUpdatableSystem<T>(T system)
    {
        if(system is IUpdatableSystem)
        {
            Updater.instance.updatables.Add(system as IUpdatableSystem);
        }
        if(system is IFixedUpdatableSystem)
        {
            Updater.instance.fixedUpdatables.Add(system as IFixedUpdatableSystem);
        }
    }

    private void ClearAllUpdates()
    {
        foreach (var system in updatables)
        {
            Updater.instance.updatables.Remove(system);
        }

        foreach (var system in fixedUpdatables)
        {
            Updater.instance.fixedUpdatables.Remove(system);
        }
    }

    protected abstract void Initialize();
}
