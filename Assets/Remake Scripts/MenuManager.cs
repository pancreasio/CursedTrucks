using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public static event FlowManager.GameFlowEvent OnMenuButtonPressed;
    public static event FlowManager.GameFlowEvent OnStartSingleplayerButtonPressed;
    public static event FlowManager.GameFlowEvent OnStartMultiplayerButtonPressed;

    public void GoToMenu()
    {
        if (OnMenuButtonPressed != null)
            OnMenuButtonPressed.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartSingleplayer()
    {
        if (OnStartSingleplayerButtonPressed != null)
            OnStartSingleplayerButtonPressed.Invoke();
    }

    public void StartMultiplayer()
    {
        if (OnStartMultiplayerButtonPressed != null)
            OnStartMultiplayerButtonPressed.Invoke();
    }
}

