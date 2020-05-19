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
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        PlayerData.instance.pre_Scene = scene.name; //记录一下当前场景
        _text = transform.Find("Text").GetComponent<Text>();
        _enter = transform.Find("Button").GetComponent<Button>();
        _enter.onClick.AddListener(OnEnter);
    }

    private void OnEnter()
    {
        SceneManager.LoadScene(PlayerData.instance.location);
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerData.instance.location)
        {
            case "learning":
                choice = 1;
                break;
            default:
                choice = 2;
                break;
        }
        if (choice ==1)
            _text.text = "你是否执行" + UserData.instance.map[PlayerData.instance.pre_Scene] + "的任务";
        else
            _text.text = "你是否要进入" + UserData.instance.map[PlayerData.instance.location];
    }
}
