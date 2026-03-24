using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public ApiRequest api;
    public CoinManager coinManager;

    public void BuySkin(int price)
    {
        if (coinManager.coins < price)
        {
            Debug.Log("Не хватает денег");
            return;
        }

        StartCoroutine(api.Post("buy",
            JsonUtility.ToJson(new BuyRequest
            {
                userId = UserService.UserId,
                price = price
            }),
            (res) =>
            {
                coinManager.coins -= price;
                coinManager.LoadCoins();
            }));
    }
}

[System.Serializable]
public class BuyRequest
{
    public int userId;
    public int price;
}