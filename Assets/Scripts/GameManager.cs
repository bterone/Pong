using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    public GameObject theBall;
    public static Text P1Score, P2Score, playerWin;

    public static void Score (string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
            P1Score.text = PlayerScore1.ToString();
        }
        else
        {
            PlayerScore2++;
            P2Score.text = PlayerScore2.ToString();
        }

        if (PlayerScore1 == 10)
        {
            playerWin.text = "PLAYER ONE WIN";
            GameObject.FindGameObjectWithTag("Ball").
                SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            playerWin.text = "PLAYER TWO WIN";
            GameObject.FindGameObjectWithTag("Ball").
                SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        else
        {
            playerWin.text = "";
        }
    }

    public void RestartGame()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }

    /*private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }*/

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        P1Score = GameObject.Find("Score1").GetComponent<Text>();
        P2Score = GameObject.Find("Score2").GetComponent<Text>();
        playerWin = GameObject.Find("Victory").GetComponent<Text>();
    }
}
