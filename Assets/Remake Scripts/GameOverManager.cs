using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static FlowManager.GameFlowEvent OnBackToMenu;
    public struct ResultData
    {
        public GameManager.Gamemode gamemode;
        public int p1Score;
        public int p2Score;
    }

    public static ResultData result;

    public GameObject singleplayerUI;
    public GameObject multiplayerUI;
    public Text winnerText;
    public Text singlePlayerText;
    public Text p1Score;
    public Text p2Score;

    void Start()
    {
        if (result.gamemode == GameManager.Gamemode.singleplayer)
        {
            multiplayerUI.SetActive(false);
            singleplayerUI.SetActive(true);
            singlePlayerText.text = "Your Score: " + result.p1Score;
        }
        if (result.gamemode == GameManager.Gamemode.multiplayer)
        {
            multiplayerUI.SetActive(true);
            singleplayerUI.SetActive(false);
            if(result.p1Score> result.p2Score)
                winnerText.text = "Player 1 Wins!";
            else
                winnerText.text = "Player 2 Wins!";

            p1Score.text = "player 1 score: " + result.p1Score.ToString();
            p2Score.text = "player 2 score: " + result.p2Score.ToString();
        }
    }

    public void BackToMenu()
    {
        if(OnBackToMenu != null)
            OnBackToMenu.Invoke();
    }
}
