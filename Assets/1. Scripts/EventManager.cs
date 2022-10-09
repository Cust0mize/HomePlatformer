using System;

public class EventManager
{
    public static event Action RemoveHealth;
    public static event Action AddHealth;

    public static void OnRemoveHealth()
    {
        RemoveHealth?.Invoke();
    }    
    
    public static void OnAddHealth()
    {
        AddHealth?.Invoke();
    }
}
