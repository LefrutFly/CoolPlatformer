using Lefrut.Extensions;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace Lefrut.Framework
{
    [RequireComponent(typeof(EntityUpdatesAdder))]
    public abstract class Facade : MonoBehaviour, IRun
    {
        [SerializeField] private List<IProvider> monoProvidersOnFacade = new List<IProvider>();
        [SerializeField] private int index;

        public List<IProvider> MonoProvidersOnFacade => monoProvidersOnFacade;
        public Property<IProvider> Providers => providers;
        public Property<IProvider> NeededProviders => neededProviders;
        public int Index => index;

        private Property<IProvider> providers = new Property<IProvider>();
        private Property<IProvider> neededProviders = new Property<IProvider>();
        private List<IEffect> allActiveEffects = new List<IEffect>();

        protected GlobalSystemStorage globalSystemStorage;


        [Button]
        public void AddAllProviders()
        {
            InitData();

            foreach (var item in NeededProviders.GetValuesArray())
            {
                if (providers.Has(item) == true) continue;

                bool isContinue = false;
                foreach (var provider in monoProvidersOnFacade)
                {
                    if (provider.GetType() == item.GetType())
                    {
                        isContinue = true;
                        break;
                    }
                }
                if (isContinue)
                {
                    continue;
                }

                var addedProvider = gameObject.AddComponent(item.GetType()) as IProvider;
                addedProvider.Facade = this;

                monoProvidersOnFacade.Add(addedProvider);
            }
        }

        [Button]
        public void RemoveAllProviders()
        {
            foreach (var provider in monoProvidersOnFacade)
            {
                DestroyImmediate(provider);
            }

            monoProvidersOnFacade.Clear();
            neededProviders.ClearAll();
        }


        protected virtual void Awake()
        {
            TakeMonoProviders();
            InitGlobalSystemStorage();
            InitSystems();
        }

        protected virtual void OnEnable()
        {
            var enableSystems = globalSystemStorage.enableSystems[index];

            foreach (var system in enableSystems)
            {
                system.Enable();
            }
        }

        protected virtual void Start()
        {
            var startableSystems = globalSystemStorage.startableSystems[index];

            foreach (var system in startableSystems)
            {
                system.Start();
            }
        }

        public virtual void Run()
        {
            var updatableSystems = globalSystemStorage.updatableSystems[index];

            foreach (var system in updatableSystems)
            {
                system.Update();
            }
        }

        public virtual void FixedRun()
        {
            var fixedUpdatableSystems = globalSystemStorage.fixedUpdatableSystems[index];

            foreach (var system in fixedUpdatableSystems)
            {
                system.FixedUpdate();
            }
        }

        public virtual void LateRun()
        {
            var lateUpdatableSystems = globalSystemStorage.lateUpdatableSystems[index];

            foreach (var system in lateUpdatableSystems)
            {
                system.LateUpdate();
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            var triggerableSystems = globalSystemStorage.triggerableSystems[index];

            foreach (var system in triggerableSystems)
            {
                system.TriggetEnter(collision);
            }
        }

        protected virtual void OnTriggerStay2D(Collider2D collision)
        {
            var triggerableSystems = globalSystemStorage.triggerableSystems[index];

            foreach (var system in triggerableSystems)
            {
                system.TriggetStay(collision);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var triggerableSystems = globalSystemStorage.triggerableSystems[index];

            foreach (var system in triggerableSystems)
            {
                system.TriggetExit(collision);
            }
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            var collidableSystems = globalSystemStorage.collidableSystems[index];

            foreach (var system in collidableSystems)
            {
                system.CollideEnter(collision);
            }
        }

        protected virtual void OnCollisionStay2D(Collision2D collision)
        {
            var collidableSystems = globalSystemStorage.collidableSystems[index];

            foreach (var system in collidableSystems)
            {
                system.CollideStay(collision);
            }
        }

        protected virtual void OnCollisionExit2D(Collision2D collision)
        {
            var collidableSystems = globalSystemStorage.collidableSystems[index];

            foreach (var system in collidableSystems)
            {
                system.CollideExit(collision);
            }
        }

        protected virtual void OnDisable()
        {
            var disableSystems = globalSystemStorage.disableSystems[index];

            foreach (var system in disableSystems)
            {
                system.Disable();
            }
        }

        protected virtual void OnDestroy()
        {
            var destroySystems = globalSystemStorage.destroySystems[index];

            foreach (var system in destroySystems)
            {
                system.Destroy();
            }
        }

        public void ApplyEffect(IEffect effect)
        {
            allActiveEffects.Add(effect);
            effect.StartEffect(this, () =>
            {
                effect.StopEffect(() =>
                {
                    allActiveEffects.Remove(effect);
                });
            });
        }

        public void CancelAllEffects()
        {
            foreach (var effect in allActiveEffects)
            {
                effect.StopEffect(() =>
                {
                    allActiveEffects.Remove(effect);
                });
            }
        }

        private void TakeMonoProviders()
        {
            providers.TakeListBack(monoProvidersOnFacade);
        }

        private void InitGlobalSystemStorage()
        {
            globalSystemStorage = GlobalSystemStorage.GetInstance();
            index = globalSystemStorage.GetIndex();
        }

        public void AddSystem(BaseSystem system)
        {
            if (system == null) return;

            system.Initialize(providers, this);


            if (system is IEnableSystem)
            {
                globalSystemStorage.AddEnableSystem(index, system as IEnableSystem);
            }
            if (system is IStartableSystem)
            {
                globalSystemStorage.AddStartableSystem(index, system as IStartableSystem);
            }
            if (system is IUpdatableSystem)
            {
                globalSystemStorage.AddUpdatableSystem(index, system as IUpdatableSystem);
            }
            if (system is IFixedUpdatableSystem)
            {
                globalSystemStorage.AddFixedUpdatableSystem(index, system as IFixedUpdatableSystem);
            }
            if (system is ILateUpdatableSystem)
            {
                globalSystemStorage.AddLateUpdatableSystem(index, system as ILateUpdatableSystem);
            }
            if (system is ITriggerableSystem)
            {
                globalSystemStorage.AddTriggerableSystem(index, system as ITriggerableSystem);
            }
            if (system is ICollidableSystem)
            {
                globalSystemStorage.AddCollidableSystem(index, system as ICollidableSystem);
            }
            if (system is IDisableSystem)
            {
                globalSystemStorage.AddDisableSystem(index, system as IDisableSystem);
            }
            if (system is IDestroySystem)
            {
                globalSystemStorage.AddDestroySystem(index, system as IDestroySystem);
            }
        }

        protected void RemoveSystem(BaseSystem system)
        {
            globalSystemStorage.RemoveSystem(index, system);
        }

        protected void AddDataFromSystem(BaseSystem system)
        {
            system.AddProviders();
            NeededProviders.AddPropertyElements(system.NeededProviders);
        }

        protected void AddNewDataProvider(IProvider monoProvider)
        {
            NeededProviders.Set(monoProvider);
        }

        protected abstract void InitSystems();

        protected abstract void InitData();
    }
}
