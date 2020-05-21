using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    private string url = "http://106.14.161.155/QianZhi/login_new.php";
    private InputField _inputAccount;
    private InputField _inputPassword;
    private Button _btnLogin;
    private Button _btnRegist;
    private Text _message;

    public GameObject _login;
    public GameObject _regist;

    private void Awake()
    {
        _inputAccount = transform.Find("InputAccount").GetComponent<InputField>();
        _inputPassword= transform.Find("InputPassword").GetComponent<InputField>();
        _btnLogin= transform.Find("BtnLogin").GetComponent<Button>();
        _btnRegist = transform.Find("Regist").GetComponent<Button>();
        _message = transform.Find("Message").GetComponent<Text>();
        _btnLogin.onClick.AddListener(onBtnLoginClick);
        _btnRegist.onClick.AddListener(onBtnRegistClick);
    }

    private void Start()
    {
        _inputAccount.text = PlayerPrefs.GetString("name");
        _inputPassword.text = PlayerPrefs.GetString("password");
    }

    private void onBtnLoginClick()
    {
        string address = _inputAccount.text;
        string password = _inputPassword.text;
        StartCoroutine(login(address, password));
    }

    private void onBtnRegistClick()
    {
        _regist.SetActive(true);
        _login.SetActive(false);
    }

    IEnumerator login(string address,string password)
    {
        Debug.Log("here");
        WWWForm add = new WWWForm();
        add.AddField("name", address);
        add.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            string[] get = information.Split('%');
            if (get[0] == "登录成功")
            {
                PlayerData.instance.name = address;
                PlayerData.instance.id = get[1];
                PlayerData.instance.gender = get[2] == "0" ? "男" : "女";
                PlayerData.instance.career = get[3];
                PlayerData.instance.family = get[4] == "5000" ? "大康" : "小康";
                PlayerData.instance.money = int.Parse(get[5]);
                PlayerData.instance.experience = int.Parse(get[6]);
                PlayerData.instance.emotion = int.Parse(get[7]);
                PlayerData.instance.level = get[8];
                PlayerData.instance.hunger = int.Parse(get[9]);
                PlayerData.instance.month = int.Parse(get[10]);
                PlayerData.instance.day = int.Parse(get[11]);
                PlayerData.instance.time = get[12];
                Debug.Log(get.Length);
                if(get.Length==14)
                    PlayerData.instance.home = get[13];
                Debug.Log(PlayerData.instance.home);
                Debug.Log(PlayerData.instance.month + PlayerData.instance.time);
                switch (get[3])
                {
                    case "医生":
                        PlayerData.instance.E_career = "doctor";
                        PlayerData.instance.address = "Prefabs/UI/Characters/doctor";
                        break;
                    case "老师":
                        PlayerData.instance.E_career = "teacher";
                        PlayerData.instance.address = "Prefabs/UI/Characters/teacher";
                        break;
                    case "警察":
                        PlayerData.instance.E_career = "police";
                        PlayerData.instance.address = "Prefabs/UI/Characters/police";
                        break;
                }
                PlayerPrefs.SetString("name", address);
                PlayerPrefs.SetString("password", password);
                Debug.Log("hhh"+PlayerPrefs.GetString("Last"));
                if(PlayerPrefs.GetString("Last")!=null|| PlayerPrefs.GetString("Last")!="Login")
                    SceneManager.LoadScene(PlayerPrefs.GetString("Last"));
                Debug.Log(PlayerData.instance.gender);
            }
            _message.text = get[0];          
        }
    }
}
