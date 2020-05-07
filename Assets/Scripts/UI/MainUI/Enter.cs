using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    private Button _enter;
    private Text _text;
    private int choice;
    // Start is called before the first frame update
    void Start()
    {
        _text = transform.Find("Text").GetComponent<Text>();
        _enter = transform.Find("Button").GetComponent<Button>();
        _enter.onClick.AddListener(OnEnter);
        switch(PlayerData.instance.location)
        {
            case "learning":
                choice = 1;
                break;
            default:
                choice = 2;
                break;
        }
    }

    private void OnEnter()
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerData.instance.pre_Scene = scene.name;
        SceneManager.LoadScene(PlayerData.instance.location);
    }

    // Update is called once per frame
    void Update()
    {
        if(choice ==1)
            _text.text = "你是否参加" + UserData.instance.map[PlayerData.instance.pre_Scene] + "的培训";
        else
            _text.text = "你是否要进入" + PlayerData.instance.location;
    }
}
