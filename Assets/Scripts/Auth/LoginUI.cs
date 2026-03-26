using TMPro;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private ApiRequest apiRequest;
    [SerializeField] private CoinUI coinUI;
    [SerializeField] private BallSkinLoader ballSkinLoader;
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject gamePanel;

    public void Register()
    {
        RegisterRequest request = new RegisterRequest
        {
            Login = loginInput.text,
            Password = passwordInput.text
        };

        StartCoroutine(apiRequest.Post<RegisterRequest, AuthResponse>("register", request, response =>
        {
            UserSession.UserId = response.UserId;

            loginPanel.SetActive(false);
            gamePanel.SetActive(true);

            coinUI.LoadCoins();
            ballSkinLoader.LoadSelectedSkin();
        }));
    }

    public void Login()
    {
        LoginRequests request = new LoginRequests
        {
            Login = loginInput.text,
            Password = passwordInput.text
        };

        StartCoroutine(apiRequest.Post<LoginRequests, AuthResponse>("login", request, response =>
        {
            UserSession.UserId = response.UserId;

            loginPanel.SetActive(false);
            gamePanel.SetActive(true);

            coinUI.LoadCoins();
            ballSkinLoader.LoadSelectedSkin();
        }));
    }
}