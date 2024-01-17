using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text roundCounter;

    void OnEnable()
    {
        roundCounter.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart level
    }

    public void Menu()
    {
        Debug.Log("Menu opened");
    }
}
