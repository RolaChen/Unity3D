using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleep : MonoBehaviour
{
    public GameObject rest;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerData.instance.time == "晚上")
        {
            rest.SetActive(true);
            button.onClick.AddListener(click);
        }           
    }

    private void click()
    {
        UserData.instance.datePass();
        StartCoroutine(UserData.instance.update());
        rest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
