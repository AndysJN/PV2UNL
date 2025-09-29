using System;
using UnityEngine.SceneManagement;

public static class GameEvents
{
    public static event Action OnPause;
    public static event Action OnResume;
    public static event Action OnDefeat;
    public static event Action OnVictory;

    public static void TriggerPauseGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        OnPause?.Invoke();
    }

    public static void TriggerResumeGame()
    {
        OnResume?.Invoke();
    }

    public static void TriggerDefeat()
    {
        OnDefeat?.Invoke();
    }

    public static void TriggerVictory()
    {
        OnVictory?.Invoke();
    }
}
