using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    Text _money;
    Text _experience;
    Text _level;
    Text _family;
    Text _career;
    Text _hunger;
    Text _name;
    Text _emotion;
    Button _head;
    string gender;
    public GameObject design;
    public GameObject illness;
    public Button leave;
    public GameObject rent;
    public Button gethome;
    public GameObject promote;
    public Button receive;

    private void Awake()
    {
        if (PlayerData.instance.gender == "男")
            gender = "Picture/boy";
        else
            gender = "Picture/girl";
    }

    // Start is called before the first frame update
    void Start()
    {
        _name = transform.Find("name").GetComponent<Text>();
        _career = transform.Find("career").GetComponent<Text>();
        _family = transform.Find("family").GetComponent<Text>();
        _experience = transform.Find("experience").GetComponent<Text>();
        _money = transform.Find("money").GetComponent<Text>();
        _level = transform.Find("level").GetComponent<Text>();
        _hunger = transform.Find("hunger").GetComponent<Text>();
        _emotion = transform.Find("emotion").GetComponent<Text>();
        _head = transform.Find("head").GetComponent<Button>();
        _head.image.sprite = Resources.Load(gender, typeof(Sprite)) as Sprite;
        _name.text = PlayerData.instance.name;
        _career.text = PlayerData.instance.career;
        _family.text = PlayerData.instance.family;
        _experience.text = PlayerData.instance.experience.ToString();
        _hunger.text = PlayerData.instance.hunger.ToString();
        _emotion.text = PlayerData.instance.emotion.ToString();
        _money.text = PlayerData.instance.money.ToString();
        _level.text = PlayerData.instance.level;
        _head.onClick.AddListener(click_design);
        if(PlayerData.instance.hunger<=10||PlayerData.instance.emotion<=10)
        {
            illness.SetActive(true);
            leave.onClick.AddListener(leaveHospital);
        }
        if(PlayerData.instance.home==null)
        {
            rent.SetActive(true);
            gethome.onClick.AddListener(setHome);
        }
        if(PlayerData.instance.experience>=2000)
        {
            promote.SetActive(true);
            receive.onClick.AddListener(getPromote);
        }
        
    }

    private void getPromote()
    {
        PlayerData.instance.experience = 0;
        PlayerData.instance.level = "住院医师";
        PlayerPrefs.SetInt("中医", 0); 
        PlayerPrefs.SetInt("牙医", 0);
        PlayerPrefs.SetInt("精神科", 0);
        StartCoroutine(UserData.instance.update());
        promote.SetActive(false);
    }

    private void setHome()
    {
        PlayerData.instance.money -= 300;
        PlayerData.instance.home = "Iron";
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Iron");
    }

    private void leaveHospital()
    {
        PlayerData.instance.hunger = 40;
        PlayerData.instance.emotion = 40;
        PlayerData.instance.money -= 100;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Hospital");
    }

    private void click_design()
    {
        design.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        _experience.text = PlayerData.instance.experience.ToString();
        _hunger.text = PlayerData.instance.hunger.ToString();
        if (PlayerData.instance.hunger <= 20)
            _hunger.color = Color.red;
        else
            _hunger.color = Color.black;
        _emotion.text = PlayerData.instance.emotion.ToString();
        if (PlayerData.instance.emotion <= 20)
            _emotion.color = Color.red;
        else
            _emotion.color = Color.black;
        _money.text = PlayerData.instance.money.ToString();
        _level.text = PlayerData.instance.level;
    }
}
