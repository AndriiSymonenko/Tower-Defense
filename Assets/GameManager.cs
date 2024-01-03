using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool endGame = false;
    void Update()
    {
        if (endGame)
            return;
       

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        endGame = true;
        Debug.Log("Game over!");
    }
}
