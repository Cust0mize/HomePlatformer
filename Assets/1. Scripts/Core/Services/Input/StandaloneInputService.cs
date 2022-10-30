using UnityEngine;

namespace Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis => StandeloneInputAxisX();
        public override bool IsJumpint => StandeloneJumpButton();
    }
}