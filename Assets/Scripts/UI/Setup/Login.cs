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

    private void Awake()
    {
        _inputAccount = transform.Find("InputAccount").GetComponent<InputField>();
        _inputPassword= transform.Find("InputPassword").GetComponent<InputField>();
        _btnLogin= transform.Find("BtnLogin").GetComponent<Button>();

        _btnLogin.onClick.AddListener(onBtnLoginClick);
    }

    private void onBtnLoginClick()
    {
        //连接服务器，等待返回数据
        //暂时用假数据，直接进入选人界面
        SceneManager.LoadScene("SelectRole");

    }
}
