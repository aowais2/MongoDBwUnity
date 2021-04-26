//playerData.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.UI;

public class playerData : MonoBehaviour
{
    public string tag;
    //public float position;
    public float[] position3D;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static playerData Parse(string json)
    {
        return JsonUtility.FromJson<playerData>(json);
    }
    public IEnumerator SavePlayerData(System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest("https://webhooks.mongodb-realm.com/api/client/v2.0/app/xx/service/xx/incoming_webhook/xx", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(this.Stringify());
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(false);
                }
            }
            else
            {
                // Debug.Log(request.downloadHandler.text);
                if (callback != null)
                {
                    callback.Invoke(request.downloadHandler.text != "{}");
                }
            }
        }
    }

}
