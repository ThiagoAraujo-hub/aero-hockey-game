using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Player1Score = 0;
    public static int Player2Score = 0;

    public GUISkin layout;
    GameObject theBall;
    GameObject Player1Paddle;
    GameObject Player2Paddle;


    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");

        Player1Paddle = GameObject.FindGameObjectWithTag("Player1");
        Player2Paddle = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {

    }

    public static void Score(string wallID)
    {
        if (wallID == "Player2Goal")
            Player1Score++;
        else
            Player2Score++;
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 70, 20, 70, 100), $"{Player1Score}");
        GUI.Label(new Rect(Screen.width / 2 + 150 + 70, 20, 70, 100), $"{Player2Score}");

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            RestartGame();
        }

        if (Player1Score == 7)
        {
            GUI.Label(new Rect(Screen.width / 2 - 320, 100, 2000, 1000), "PLAYER ONE WINS");
            ResetGame();
        }
        else if (Player2Score == 7)
        {
            GUI.Label(new Rect(Screen.width / 2 - 320, 100, 2000, 1000), "PLAYER TWO WINS");
            ResetGame();
        }
    }

    void ResetGame(){
        theBall.SendMessage("ResetBall", 0.5f, SendMessageOptions.RequireReceiver);

        Player1Paddle.SendMessage("ResetPlayerPosition", 0.5f, SendMessageOptions.RequireReceiver);
        Player2Paddle.SendMessage("ResetPlayerPosition", 0.5f, SendMessageOptions.RequireReceiver);
    }

    void RestartGame(){
        Player1Score = 0;
        Player2Score = 0;

        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);

        Player1Paddle.SendMessage("OnRestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        Player2Paddle.SendMessage("OnRestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }
}