using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class working : MonoBehaviour
{
    // Start is called before the first frame update
    private string url = "http://106.14.161.155/QianZhi/working.php";
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button next;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text question;
    public GameObject work;
    public GameObject finish;
    public Text score;
    public Text report;

    ArrayList a1 = new ArrayList();
    ArrayList a2 = new ArrayList();
    ArrayList a3 = new ArrayList();
    ArrayList a4 = new ArrayList();
    ArrayList q = new ArrayList();
    ArrayList result = new ArrayList();

    int index = 1;
    int right = 0;
    private int[] qqq = new int[3];

    void Start()
    {
        StartCoroutine(getworking());
        next.onClick.AddListener(Next);
        button1.onClick.AddListener(bt1);
        button2.onClick.AddListener(bt2);
        button3.onClick.AddListener(bt3);
        button4.onClick.AddListener(bt4);
    }

    private void bt4()
    {
        switch (result[index - 1].ToString())
        {
            case "1":
                button4.GetComponent<Image>().color = Color.red;
                button1.GetComponent<Image>().color = Color.green;
                break;
            case "2":
                button4.GetComponent<Image>().color = Color.red;
                button2.GetComponent<Image>().color = Color.green;
                break;
            case "3":
                button4.GetComponent<Image>().color = Color.red;
                button3.GetComponent<Image>().color = Color.green;
                break;
            case "4":
                button4.GetComponent<Image>().color = Color.green;
                right++;
                break;
        }
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button4.enabled = false;
        next.gameObject.SetActive(true);
    }

    private void bt3()
    {
        switch (result[index - 1].ToString())
        {
            case "1":
                button3.GetComponent<Image>().color = Color.red;
                button1.GetComponent<Image>().color = Color.green;
                break;
            case "2":
                button3.GetComponent<Image>().color = Color.red;
                button2.GetComponent<Image>().color = Color.green;
                break;
            case "3":                
                button3.GetComponent<Image>().color = Color.green;
                right++;
                break;
            case "4":
                button3.GetComponent<Image>().color = Color.red;
                button4.GetComponent<Image>().color = Color.green;
                break;
        }
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button4.enabled = false;
        next.gameObject.SetActive(true);
    }

    private void bt2()
    {
        switch (result[index - 1].ToString())
        {
            case "1":
                button2.GetComponent<Image>().color = Color.red;
                button1.GetComponent<Image>().color = Color.green;
                break;
            case "2":
                button2.GetComponent<Image>().color = Color.green;
                right++;
                break;
            case "3":
                button2.GetComponent<Image>().color = Color.red;
                button3.GetComponent<Image>().color = Color.green;
                break;
            case "4":
                button2.GetComponent<Image>().color = Color.red;
                button4.GetComponent<Image>().color = Color.green;
                break;
        }
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button4.enabled = false;
        next.gameObject.SetActive(true);
    }

    private void bt1()
    {            
        switch(result[index - 1].ToString())
        {
            case "1":
                button1.GetComponent<Image>().color = Color.green;
                right++;
                break;
            case "2":
                button1.GetComponent<Image>().color = Color.red;
                button2.GetComponent<Image>().color = Color.green;
                break;
            case "3":
                button1.GetComponent<Image>().color = Color.red;
                button3.GetComponent<Image>().color = Color.green;
                break;
            case "4":
                button1.GetComponent<Image>().color = Color.red;
                button4.GetComponent<Image>().color = Color.green;
                break;
        }
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button4.enabled = false;
        next.gameObject.SetActive(true);
    }

    private void Next()
    {
        if (index == q.Count)
        {
            int i = (index - right) * 20 - 5;
            int j = right * 20;
            score.text = "一共" +index + "道题，共答对" +right+ "道" ;
            report.text = "本次扣除体力50点，愉悦值"+i.ToString()+"点\n提升"+j.ToString()+"点经验值";
            PlayerData.instance.experience = PlayerData.instance.experience + j;
            PlayerData.instance.emotion = PlayerData.instance.emotion - i;
            PlayerData.instance.hunger = PlayerData.instance.hunger - 50;
            UserData.instance.datePass();
            StartCoroutine(UserData.instance.update());
            finish.SetActive(true);
            work.SetActive(false);
        }
        else
        {
            next.gameObject.SetActive(false);
            button1.GetComponent<Image>().color = Color.white;
            button2.GetComponent<Image>().color = Color.white;
            button3.GetComponent<Image>().color = Color.white;
            button4.GetComponent<Image>().color = Color.white;
            button1.enabled = true;
            button2.enabled = true;
            button3.enabled = true;
            button4.enabled = true;
            question.text = q[index].ToString();
            answer1.text = a1[index].ToString();
            answer2.text = a2[index].ToString();
            answer3.text = a3[index].ToString();
            answer4.text = a4[index].ToString();
            Debug.Log(result[index].ToString());
            index = index + 1;
        }
    }

    IEnumerator getworking()
    {
        Debug.Log(PlayerData.instance.pre_Scene);
        Debug.Log("learning");
        WWWForm add = new WWWForm();
        add.AddField("major", UserData.instance.map[PlayerData.instance.pre_Scene]);
        add.AddField("level", PlayerData.instance.level);
        //add.AddField("level", "实习生");
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            Debug.Log(information);
            string[] get = information.Split('@');
            //随机找3题
            System.Random rd = new System.Random();
            int tempp;
            qqq[0] = rd.Next(0, get.Length - 1);
            tempp = rd.Next(0, get.Length - 1);
            while(tempp==qqq[0])
            {
                tempp = rd.Next(0, get.Length - 1);
            }
            qqq[1] = tempp;
            tempp = rd.Next(0, get.Length - 1);
            while(tempp == qqq[0]|| tempp == qqq[1])
            {
                tempp = rd.Next(0, get.Length - 1);
            }
            qqq[2] = tempp;

            for (int i = 0; i < 3; i++)
            {
                string[] temp = get[qqq[i]].Split('*');
                q.Add(temp[0]);
                a1.Add(temp[1]);
                a2.Add(temp[2]);
                a3.Add(temp[3]);
                a4.Add(temp[4]);
                result.Add(temp[5]);
            }
            question.text = q[0].ToString();
            answer1.text = a1[0].ToString();
            answer2.text = a2[0].ToString();
            answer3.text = a3[0].ToString();
            answer4.text = a4[0].ToString();
            Debug.Log(result[0].ToString());
        }
    }
}
