using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;

    void Start()
    {
       StartCoroutine (FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float timeFade = 1f;

        while (timeFade > 0)
        {
            timeFade -= Time.deltaTime;
            float a = fadeCurve.Evaluate(timeFade);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;

        }
    }

    IEnumerator FadeOut(string scene)
    {
        float timeFade = 0f;

        while (timeFade < 1f)
        {
            timeFade += Time.deltaTime;
            float a = fadeCurve.Evaluate(timeFade);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;

        }

        SceneManager.LoadScene(scene);
    }
}
