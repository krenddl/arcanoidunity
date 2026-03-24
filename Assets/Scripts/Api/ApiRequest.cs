using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class ApiRequest : MonoBehaviour
{
    private string baseUrl = "http://localhost:5293/api/";

    public IEnumerator Post(string endpoint, string json, System.Action<string> callback)
    {
        UnityWebRequest request = new UnityWebRequest(baseUrl + endpoint, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            callback?.Invoke(request.downloadHandler.text);
        else
            Debug.LogError(request.error);
    }

    public IEnumerator Get(string endpoint, System.Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + endpoint);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            callback?.Invoke(request.downloadHandler.text);
        else
            Debug.LogError(request.error);
    }
}