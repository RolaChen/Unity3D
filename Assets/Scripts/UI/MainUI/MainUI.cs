using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    Text _reputation;
    Button _head;
    string gender;

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
        _reputation = transform.Find("reputation").GetComponent<Text>();
        _head = transform.Find("head").GetComponent<Button>();
        _head.image.sprite = Resources.Load(gender, typeof(Sprite)) as Sprite;
        _name.text = PlayerData.instance.name;
        _career.text = PlayerData.instance.career;
        _family.text = PlayerData.instance.family;
        _experience.text = PlayerData.instance.experience.ToString();
        _hunger.text = PlayerData.instance.hunger.ToString();
        _reputation.text = PlayerData.instance.reputation.ToString();
        _money.text = PlayerData.instance.money.ToString();
        _level.text = PlayerData.instance.level;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
