using UnityEngine;
using TMPro;
using System.Collections;

public class CoinManager : MonoBehaviour
{
    public TMP_Text coinText;
    public ApiRequest api;

    public int coins;

    void Start()
    {
        LoadCoins();
    }

    public void LoadCoins()
    {
        StartCoroutine(api.Get($"coins/{UserService.UserId}", (response) =>
        {
            coins = int.Parse(response);
            coinText.text = coins.ToString();
        }));
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }
}