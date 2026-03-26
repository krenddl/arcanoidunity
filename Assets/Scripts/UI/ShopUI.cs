using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ApiRequest apiRequest;
    [SerializeField] private CoinUI coinUI;
    [SerializeField] private BallSkinLoader ballSkinLoader;

    public void BuySkin(int skinId)
    {
        if (!UserSession.IsAuth)
            return;

        BuySkinRequest request = new BuySkinRequest
        {
            UserId = UserSession.UserId,
            SkinId = skinId
        };

        StartCoroutine(apiRequest.Post<BuySkinRequest, BuySkinResponse>("buy-skin", request, response =>
        {
            coinUI.LoadCoins();
        }));
    }

    public void SelectSkin(int skinId)
    {
        if (!UserSession.IsAuth)
            return;

        SelectSkinRequest request = new SelectSkinRequest
        {
            UserId = UserSession.UserId,
            SkinId = skinId
        };

        StartCoroutine(apiRequest.Post<SelectSkinRequest, SimpleResponse>("select-skin", request, response =>
        {
            ballSkinLoader.LoadSelectedSkin();
        }));
    }
}