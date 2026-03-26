using UnityEngine;

public class BallSkinLoader : MonoBehaviour
{
    [SerializeField] private ApiRequest apiRequest;
    [SerializeField] private SpriteRenderer ballSpriteRenderer;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite goldSprite;

    public void LoadSelectedSkin()
    {
        if (!UserSession.IsAuth)
            return;

        StartCoroutine(apiRequest.Get<SelectedSkinResponse>($"{UserSession.UserId}/selected-skin", response =>
        {
            ApplySkin(response.SkinId);
        }));
    }

    private void ApplySkin(int skinId)
    {
        switch (skinId)
        {
            case 2:
                ballSpriteRenderer.sprite = redSprite;
                break;
            case 3:
                ballSpriteRenderer.sprite = blueSprite;
                break;
            case 4:
                ballSpriteRenderer.sprite = goldSprite;
                break;
            default:
                ballSpriteRenderer.sprite = defaultSprite;
                break;
        }
    }
}