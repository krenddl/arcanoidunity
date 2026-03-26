using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private ApiRequest apiRequest;

    public int CurrentCoins { get; private set; }

    public void LoadCoins()
    {
        if (!UserSession.IsAuth)
            return;

        StartCoroutine(apiRequest.Get<CoinsResponse>($"{UserSession.UserId}/coins", response =>
        {
            CurrentCoins = response.Coins;
            coinsText.text = $"Coins: {CurrentCoins}";
        }));
    }

    public void AddCoins(int amount)
    {
        if (!UserSession.IsAuth)
            return;

        AddCoinsRequest request = new AddCoinsRequest
        {
            UserId = UserSession.UserId,
            Amount = amount
        };

        StartCoroutine(apiRequest.Post<AddCoinsRequest, BuySkinResponse>("add-coins", request, response =>
        {
            CurrentCoins = response.Coins;
            coinsText.text = $"Coins: {CurrentCoins}";
        }));
    }
}