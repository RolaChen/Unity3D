using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectRole : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle[] toggles;
    private Button _submit;
    private string _gender="男", _career= "医生";
    private string family;
    public GameObject[] characterPrefebs;
    Dictionary<string, GameObject> characters;
    public GameObject player;
    private Text _family;
    private string url = "http://106.14.161.155/QianZhi/regist_player.php";

    void Awake()
    {
        _submit = transform.Find("Enter").GetComponent<Button>();
        _submit.onClick.AddListener(OnBtnSubmitClick);
        _family = transform.Find("RoleList/Viewport/Content/family").GetComponent<Text>();

        //toggle binding
        int i = 0;
        foreach (Toggle t in toggles)
        {
            int index = i;
            i++;
            t.onValueChanged.AddListener((isOn) => { OnCareerChanged(index, isOn); });
        }

        //character initialize
        characters = new Dictionary<string, GameObject>();
        for(i=0;i<characterPrefebs.Length;i++)
        {
            GameObject temp = GameObject.Instantiate(characterPrefebs[i],
                player.transform.position, player.transform.rotation) as GameObject;
            temp.transform.parent = transform;
            temp.SetActive(false);
            characters.Add(characterPrefebs[i].name, temp);
        }
        characters["doctor"].SetActive(true);

        //family initialize


        int rand = System.DateTime.Now.Second;
        if (rand % 10 == 0)
            family = "大康";
        else
            family = "小康";
        _family.text = family;
    }
    void OnCareerChanged(int index, bool isOn)
    {
        if(isOn)
        {
            switch(toggles[index].name)
            {
                case "male":
                    _gender = "男";
                    break;
                case "female":
                    _gender = "女";
                    break;
                case "doctor":
                    _career = "医生";
                    characters["doctor"].SetActive(true);
                    break;
                case "teacher":
                    _career = "老师";
                    characters["teacher"].SetActive(true);
                    break;
                case "police":
                    _career = "警察";
                    characters["police"].SetActive(true);
                    break;
            }
        }
        else
        {
            switch (toggles[index].name)
            {
                case "male":
                    break;
                case "female":
                    break;
                case "doctor":
                    characters["doctor"].SetActive(false);
                    break;
                case "teacher":
                    characters["teacher"].SetActive(false);
                    break;
                case "police":
                    characters["police"].SetActive(false);
                    break;
            }
        }
    }

    void OnBtnSubmitClick()
    {
        PlayerData.instance.gender = _gender;
        PlayerData.instance.career = _career;
        PlayerData.instance.family = family;
        switch(_career)
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
        StartCoroutine(regist());
        PlayerData.instance.money = PlayerData.instance.family == "大康" ? 5000 : 2000;
        PlayerData.instance.experience = 0;
        PlayerData.instance.hunger = 100;
        PlayerData.instance.emotion = 100;
        PlayerData.instance.level = "实习生";
    }

    IEnumerator regist()
    {
        WWWForm add = new WWWForm();
        add.AddField("id", PlayerData.instance.id);
        // 0 male 1 female
        add.AddField("gender", PlayerData.instance.gender=="男"?0:1);
        add.AddField("career", PlayerData.instance.career);
        add.AddField("family", PlayerData.instance.family=="大康"?5000:2000);
        UnityWebRequest webRequest = UnityWebRequest.Post(url, add);
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            string information = webRequest.downloadHandler.text.ToString();
            if (information == "succeed")
            {
                SceneManager.LoadScene("LoginScene");
            }
        }
    }
}
