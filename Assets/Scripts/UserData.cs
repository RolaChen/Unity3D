using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserData : Singleton<UserData>
{
    public Dictionary<string, string> map = new Dictionary<string, string>();
    private int[] months = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private string url = "http://106.14.161.155/QianZhi/update.php";

    public IEnumerator update()
    {
        WWWForm add = new WWWForm();
        add.AddField("money", PlayerData.instance.money);
        add.AddField("experience", PlayerData.instance.experience);
        add.AddField("level", PlayerData.instance.level);
        add.AddField("emotion", PlayerData.instance.emotion);
        add.AddField("hunger", PlayerData.instance.hunger);
        add.AddField("month", PlayerData.instance.month);
        add.AddField("day", PlayerData.instance.day);
        add.AddField("time", PlayerData.instance.time);
        add.AddField("id", PlayerData.instance.id);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        Debug.Log("update4");
        yield return webRequest.SendWebRequest();
        Debug.Log("update5");
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            Debug.Log(information);
        }
    }

    public void datePass()
    {
        if (PlayerData.instance.time == "上午")
            PlayerData.instance.time = "下午";
        else
        {
            PlayerData.instance.time = "上午";
            PlayerData.instance.day++;
            if (PlayerData.instance.day > months[PlayerData.instance.month])
            {
                PlayerData.instance.day = 1;
                PlayerData.instance.month++;
                if (PlayerData.instance.month > 12)
                    PlayerData.instance.month = 1;
            }

        }
    }
    
}
