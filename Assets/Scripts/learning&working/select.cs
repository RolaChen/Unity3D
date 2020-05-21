using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    public GameObject learning;
    public GameObject working;
    public GameObject myself;
    public Text text;
    Button _learn;
    Button _work;
    Button _return;
    // Start is called before the first frame update
    void Start()
    {
        _learn = transform.Find("learning").GetComponent<Button>();
        _work = transform.Find("working").GetComponent<Button>();
        _return = transform.Find("return").GetComponent<Button>();
        _return.onClick.AddListener(Click_return);
        _learn.onClick.AddListener(click_learn);
        _work.onClick.AddListener(click_work);
    }

    private void Click_return()
    {
        SceneManager.LoadScene(PlayerData.instance.pre_Scene);
    }

    private void click_work()
    {
        if(PlayerData.instance.time=="晚上")
        {
            text.text = "现在是晚上了，请先回家休息，明天再来";
        }
        else if(PlayerPrefs.GetInt(UserData.instance.map[PlayerData.instance.pre_Scene])<2)
        {
            text.text = "该科室学习不足两次，不能开始做任务";
        }      
        else
        {
            working.SetActive(true);
            myself.SetActive(false);
        }
    }

    private void click_learn()
    {
        if (PlayerData.instance.time == "晚上")
        {
            text.text = "现在是晚上了，请先回家休息，明天再来";
        }
        else
        {
            learning.SetActive(true);
            myself.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
