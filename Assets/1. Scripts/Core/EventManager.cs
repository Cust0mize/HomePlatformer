using System;

public class EventManager
{
    public static event Action RemoveHealth;

    public static event Action AddHealth;

    public static event Action ResetTime;

    public static event Action<float> JumpGun;

    public static void OnRemoveHealth() => RemoveHealth?.Invoke();

    public static void OnAddHealth() => AddHealth?.Invoke();

    public static void OnResetTime() => ResetTime?.Invoke();

    public static void OnJumpGun(float time) => JumpGun?.Invoke(time);
}