using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class learning : MonoBehaviour
{
    private string url = "http://106.14.161.155/QianZhi/learning.php";
    string major;
    ArrayList _urls = new ArrayList();
    ArrayList _knowledge = new ArrayList();
    ArrayList _name = new ArrayList();

    public Text title;
    public Text knowledge;
    public Image picture;
    public Button next;
    public GameObject learn;
    public GameObject finish;

    int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        major = "中医";
        StartCoroutine(getLearning());
        next.onClick.AddListener(Next);
    }

    private void Next()
    {
        if (index == _urls.Count)
        {
            finish.SetActive(true);
            learn.SetActive(false);
        }
        else
        {
            title.text = _name[index].ToString();
            knowledge.text = _knowledge[index].ToString();
            picture.sprite = Resources.Load(_urls[index].ToString(), typeof(Sprite)) as Sprite;
            index = index + 1;
        }
    }

    IEnumerator getLearning()
    {
        Debug.Log("learning");
        WWWForm add = new WWWForm();
        add.AddField("major", major);
        //add.AddField("level", PlayerData.instance.level);
        add.AddField("level", "实习生");
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            Debug.Log(information);
            string[] get = information.Split('@'); 
            for (int i = 0; i < get.Length-1; i++)
            {
                //Debug.Log("222"+get[i]);
                string[] temp = get[i].Split('*');
                _urls.Add(temp[0]);
                _knowledge.Add(temp[1]);
                _name.Add(temp[2]);
                Debug.Log(_urls.Count);
            }
            title.text = _name[0].ToString();
            knowledge.text=_knowledge[0].ToString();
            picture.sprite = Resources.Load(_urls[0].ToString(), typeof(Sprite)) as Sprite;
            }
        }
}
