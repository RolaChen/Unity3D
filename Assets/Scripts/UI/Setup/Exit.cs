using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    private Button _exit;
    private string url = "http://106.14.161.155/QianZhi/exit.php";

    void Start()
    {
        _exit = transform.Find("Exit").GetComponent<Button>();
        _exit.onClick.AddListener(exit);
    }

    private void exit()
    {
        StartCoroutine(live());
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    IEnumerator live()
    {
        WWWForm add = new WWWForm();
        add.AddField("id", PlayerData.instance.id);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
    }

}
