using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Regist : MonoBehaviour
{
    private string url = "http://106.14.161.155/QianZhi/regist.php";
    public GameObject _login;
    public GameObject _regist;
    private InputField _name;
    private InputField _password;
    private InputField _repassword;
    private Button _btnBack;
    private Button _btnRegist;
    private Text _message;

    void Start()
    {
        _name = transform.Find("Name").GetComponent<InputField>();
        _password = transform.Find("Password").GetComponent<InputField>();
        _repassword = transform.Find("re_Password").GetComponent<InputField>();
        _btnBack = transform.Find("Back").GetComponent<Button>();
        _btnRegist = transform.Find("Regist").GetComponent<Button>();
        _message = transform.Find("Message").GetComponent<Text>();
        _btnBack.onClick.AddListener(OnBtnBackClick);
        _btnRegist.onClick.AddListener(OnBtnRegistClick);
    }

    private void OnBtnBackClick()
    {
        _login.SetActive(true);
        _regist.SetActive(false);
    }

    private void OnBtnRegistClick()
    {
        if (_password.text != _repassword.text)
            _message.text = "两次密码不一致";
        else
        {
            StartCoroutine(regist(_name.text, _password.text));
        }         
    }

    IEnumerator regist(string name, string password)
    {
        WWWForm add = new WWWForm();
        add.AddField("name", name);
        add.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            //Debug.Log(information);
            string[] get = information.Split('%');
            if (get[0] == "succeed")
            {
                PlayerData.instance.name = name;
                PlayerData.instance.id = get[1];
                PlayerPrefs.SetString("name", name);
                PlayerPrefs.SetString("password", password);
                SceneManager.LoadScene("SelectRole");
            }
            else
                _message.text = get[0];
        }
    }
}
