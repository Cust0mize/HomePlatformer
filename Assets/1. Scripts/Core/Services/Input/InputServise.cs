using UnityEngine;

namespace Services.Input
{
    public abstract partial class InputService : IInputService
    {
        //protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";
        protected const string Button = "Fire";

        public abstract Vector2 Axis { get; }
        public abstract bool AttackIsActive { get; }

        protected static Vector2 StandeloneInputAxisX() =>
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), 0f);

        public static bool StandeloneIsAttackButtonDown() =>
            UnityEngine.Input.GetMouseButtonDown(0);

    }
}
