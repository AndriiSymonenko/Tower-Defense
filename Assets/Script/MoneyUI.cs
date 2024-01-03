using System.Collections;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyText;

    void Update()
    {
        moneyText.text = "$" +  PlayerStats.Money.ToString();
    }
}
