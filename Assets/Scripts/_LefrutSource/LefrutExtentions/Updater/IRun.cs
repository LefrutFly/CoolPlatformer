using System;

namespace Lefrut.Extensions
{
    public interface IRun
    {
        void Run();
        void FixedRun();
        void LateRun();
    }
}