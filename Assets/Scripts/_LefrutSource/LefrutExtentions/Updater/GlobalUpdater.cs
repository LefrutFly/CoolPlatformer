using System.Collections.Generic;
using UnityEngine;

namespace Lefrut.Extensions
{
    [DefaultExecutionOrder(-999)]
    public sealed class GlobalUpdater : DIExtension<GlobalUpdater>
    {
        public List<IRun> updatables = new List<IRun>();


        public void AddUpdates(IRun run)
        {
            updatables.Add(run);
        }


        public void RemoveUpdates(IRun run)
        {
            updatables.Remove(run);
        }


        private void Update()
        {
            for (int i = 0; i < updatables.Count; i++)
            {
                if (updatables[i] != null)
                {
                    updatables[i].Run();
                }
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < updatables.Count; i++)
            {
                if (updatables[i] != null)
                {
                    updatables[i].FixedRun();
                }
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < updatables.Count; i++)
            {
                if (updatables[i] != null)
                {
                    updatables[i].LateRun();
                }
            }
        }
    }
}