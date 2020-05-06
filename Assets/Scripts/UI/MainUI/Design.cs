using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Design : MonoBehaviour
{

    Button _commute;
    Button _exit;
    public GameObject commute;
    public GameObject design;


    // Start is called before the first frame update
    void Start()
    {
        _commute = transform.Find("commute_bt").GetComponent<Button>();
        _commute.onClick.AddListener(click_commute);
        _exit = transform.Find("exit").GetComponent<Button>();
        _exit.onClick.AddListener(click_exit);
    }

    private void click_exit()
    {
        design.SetActive(false);
    }

    private void click_commute()
    {
        commute.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
