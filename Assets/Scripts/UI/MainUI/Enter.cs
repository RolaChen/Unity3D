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
    // Start is called before the first frame update
    void Start()
    {
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
        _text.text = "你是否要进入" + PlayerData.instance.location;
    }
}
