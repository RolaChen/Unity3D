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
                //PlayerData.instance.money = int.Parse(get[4]);
                //PlayerData.instance.experience = int.Parse(get[5]);
                //PlayerData.instance.hunger = int.Parse(get[6]);
                //PlayerData.instance.level = get[7];
                PlayerPrefs.SetString("name", address);
                PlayerPrefs.SetString("password", password);
                SceneManager.LoadScene("SimpleTown_DemoScene");
                Debug.Log(PlayerData.instance.gender);
            }
            _message.text = get[0];          
        }
    }
}
