using UnityEngine;

namespace Services.Input
{
    public abstract partial class InputService : IInputService
    {
        protected const string Horizontal = nameof(Horizontal);
        protected const string Button = "Fire";
        public abstract Vector2 Axis { get; }
        public abstract bool IsJumpint { get; }

        protected static Vector2 StandeloneInputAxisX() =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), 0f);

        protected static bool StandeloneJumpButton() =>
            UnityEngine.Input.GetKey(KeyCode.Space);

        public static bool StandeloneIsAttackButtonDown() =>
            UnityEngine.Input.GetMouseButtonDown(0);
    }
}