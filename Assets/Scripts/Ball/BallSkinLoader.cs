using UnityEngine;

public class BallSkinLoader : MonoBehaviour
{
    [SerializeField] private ApiRequest apiRequest;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite redSprite;
    [SerializeField] private Sprite blueSprite;
    [SerializeField] private Sprite goldSprite;

    [SerializeField] private SpriteRenderer level1BallRenderer;
    [SerializeField] private SpriteRenderer level2BallRenderer;
    [SerializeField] private SpriteRenderer level3BallRenderer;

    public static int CurrentSkinId = 1;
    public static BallSkinLoader Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadSelectedSkin()
    {
        if (!UserSession.IsAuth)
            return;

        StartCoroutine(apiRequest.Get<SelectedSkinResponse>($"{UserSession.UserId}/selected-skin", response =>
        {
            CurrentSkinId = response.skinId;
            ApplySkinToAllSceneBalls();
        }));
    }

    public void ApplySkinToAllSceneBalls()
    {
        ApplySkin(level1BallRenderer, CurrentSkinId);
        ApplySkin(level2BallRenderer, CurrentSkinId);
        ApplySkin(level3BallRenderer, CurrentSkinId);
    }

    public void ApplySkinToRenderer(SpriteRenderer targetRenderer)
    {
        ApplySkin(targetRenderer, CurrentSkinId);
    }

    private void ApplySkin(SpriteRenderer targetRenderer, int skinId)
    {
        if (targetRenderer == null)
            return;

        switch (skinId)
        {
            case 2:
                targetRenderer.sprite = redSprite;
                break;
            case 3:
                targetRenderer.sprite = blueSprite;
                break;
            case 4:
                targetRenderer.sprite = goldSprite;
                break;
            default:
                targetRenderer.sprite = defaultSprite;
                break;
        }
    }
}