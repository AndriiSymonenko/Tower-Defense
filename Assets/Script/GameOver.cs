using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text roundCounter;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    void OnEnable()
    {
        roundCounter.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //restart level
    }

    public void Menu()
    {
        Debug.Log("Menu opened");
        sceneFader.FadeTo(menuSceneName);
    }
}
