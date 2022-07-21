using UnityEngine;

namespace Interfaces
{
    public interface IMoveable
    {
        float Velocity { get; }

        void Move(Vector3 direction);
    }
}