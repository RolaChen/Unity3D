using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
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
        if (ConnectMySql.instance.login(address, password))
        {
            _message.text = "登入成功";
            SceneManager.LoadScene("SimpleTown_DemoScene");
        }
        else
            _message.text = "用户名或密码错误";

    }
}
