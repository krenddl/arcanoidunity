using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ApiRequest : MonoBehaviour
{
    [SerializeField] private string baseUrl = "http://localhost:5011/api/user/";

    public IEnumerator Post<TRequest, TResponse>(string endpoint, TRequest data, Action<TResponse> onSuccess)
    {
        string json = JsonUtility.ToJson(data);

        using UnityWebRequest request = new UnityWebRequest(baseUrl + endpoint, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            TResponse result = JsonUtility.FromJson<TResponse>(request.downloadHandler.text);
            onSuccess?.Invoke(result);
        }
        else
        {
            Debug.LogError($"POST ERROR: {request.error}\n{request.downloadHandler.text}");
        }
    }

    public IEnumerator Get<TResponse>(string endpoint, Action<TResponse> onSuccess)
    {
        using UnityWebRequest request = UnityWebRequest.Get(baseUrl + endpoint);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            TResponse result = JsonUtility.FromJson<TResponse>(request.downloadHandler.text);
            onSuccess?.Invoke(result);
        }
        else
        {
            Debug.LogError($"GET ERROR: {request.error}\n{request.downloadHandler.text}");
        }
    }
}