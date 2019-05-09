using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GameObject theBall, paddleOne, paddleTwo;
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
        UpdateScore();
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        paddleOne.Transform.position = new Vector3(-4f,0f,0f);
        paddleTwo.Transform.position = new Vector3(4f,0f,0f);
    }
    
    public void UpdateScore(){
        P1Score.text = PlayerScore1.ToString();
        P2Score.text = PlayerScore2.ToString();
    }

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        P1Score = GameObject.Find("Score1").GetComponent<Text>();
        P2Score = GameObject.Find("Score2").GetComponent<Text>();
        playerWin = GameObject.Find("Victory").GetComponent<Text>();
        paddleOne = GameObject.Find("Paddle1");
        paddleTwo = GameObject.Find("Paddle2");
    }

}
