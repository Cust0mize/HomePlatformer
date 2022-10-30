using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        public Vector2 Axis { get; }
        public bool IsJumpint { get; }
    }
}