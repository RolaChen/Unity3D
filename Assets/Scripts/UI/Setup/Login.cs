using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    private string url = "http://106.14.161.155/QianZhi/login.php";
    private InputField _inputAccount;
    private InputField _inputPassword;
    private Button _btnLogin;
    private Text _message;

    private void Awake()
    {
        _inputAccount = transform.Find("InputAccount").GetComponent<InputField>();
        _inputPassword= transform.Find("InputPassword").GetComponent<InputField>();
        _btnLogin= transform.Find("BtnLogin").GetComponent<Button>();
        _message = transform.Find("Message").GetComponent<Text>();
        _btnLogin.onClick.AddListener(onBtnLoginClick);
    }

    private void onBtnLoginClick()
    {
        //连接服务器，等待返回数据
        //暂时用假数据，直接进入选人界面
        //SceneManager.LoadScene("SelectRole");
        //ConnectMySql.instance.SelectWhere("player", new string[] { "*" }, new string[] { "login" },
        //new string[] { "=" }, new string[] { "1" });
        //Debug.Log(PlayerPrefs.GetString("name"));
        //Debug.Log(PlayerPrefs.GetString("password"));
        //Debug.Log(PlayerPrefs.GetString("login"));
        string address = _inputAccount.text;
        string password = _inputPassword.text;
        StartCoroutine(login(address, password));
    }

    IEnumerator login(string address,string password)
    {
        WWWForm add = new WWWForm();
        add.AddField("name", address);
        add.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        //异常处理，很多博文用了error!=null这是错误的，请看下文其他属性部分
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            string[] get = information.Split('%');
            if (get[0] == "登录成功")
            {
                PlayerPrefs.SetString("name", address);
                PlayerPrefs.SetString("id", get[1]);
                PlayerPrefs.SetString("career", get[2]);
                PlayerPrefs.SetString("home", get[3]);
                PlayerPrefs.SetString("money", get[4]);
                PlayerPrefs.SetString("experience", get[5]);
                PlayerPrefs.SetString("hunger", get[6]);
                PlayerPrefs.SetString("level", get[7]);
                SceneManager.LoadScene("SimpleTown_DemoScene");
            }
            _message.text = get[0];          
        }
    }
}
