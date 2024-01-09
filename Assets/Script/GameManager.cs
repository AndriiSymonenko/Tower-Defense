using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool GameOver;

    void Start()
    {
        GameOver = false;
    }
    void Update()
    {
        if (GameOver)
            return;
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
       

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameOver = true;
        gameOverUI.SetActive(true);
    }
}
