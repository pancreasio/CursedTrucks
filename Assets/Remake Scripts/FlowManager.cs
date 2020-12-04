using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public static FlowManager gameInstance;
    public delegate void GameFlowEvent();
    public delegate void ChangeSceneAction(int index);

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (gameInstance == null)
            gameInstance = this;
        else
            Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        if (gameInstance != null)
            gameInstance = null;
    }

    void Start()
    {
        MenuManager.OnStartSingleplayerButtonPressed += StartSingleplayer;
        MenuManager.OnStartMultiplayerButtonPressed += StartMultiplayer;
        MenuManager.OnMenuButtonPressed += GoToMenu;
    }

    void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void StartSingleplayer()
    {
        GameManager.currentGamemode = GameManager.Gamemode.singleplayer;
        SceneManager.LoadScene(1);
    }

    private void StartMultiplayer()
    {
        GameManager.currentGamemode = GameManager.Gamemode.multiplayer;
        SceneManager.LoadScene(1);
    }
}
