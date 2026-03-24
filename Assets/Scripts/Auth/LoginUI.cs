using UnityEngine;
using TMPro;
using System.Collections;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField loginInput;
    public TMP_InputField passwordInput;

    public ApiRequest api;

    public void Login()
    {
        StartCoroutine(api.Post("login",
            JsonUtility.ToJson(new LoginRequest
            {
                login = loginInput.text,
                password = passwordInput.text
            }),
            (response) =>
            {
                var res = JsonUtility.FromJson<LoginResponse>(response);
                UserService.UserId = res.userId;

                Debug.Log("Успешный вход");
            }));
    }
}

[System.Serializable]
public class LoginRequest
{
    public string login;
    public string password;
}

[System.Serializable]
public class LoginResponse
{
    public int userId;
}