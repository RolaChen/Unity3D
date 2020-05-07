using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishLearning : MonoBehaviour
{
    Button _return;

    void Start()
    {
        _return = transform.Find("return").GetComponent<Button>();
        _return.onClick.AddListener(Click_return);
    }

    private void Click_return()
    {
        SceneManager.LoadScene(PlayerData.instance.pre_Scene);
    }

    
}
