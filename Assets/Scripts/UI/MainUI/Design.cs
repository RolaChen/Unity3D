using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Design : MonoBehaviour
{

    Button _commute;
    Button _exit;
    Button _time;
    public GameObject commute;
    public GameObject design;
    public GameObject date;


    // Start is called before the first frame update
    void Start()
    {
        _commute = transform.Find("commute_bt").GetComponent<Button>();
        _commute.onClick.AddListener(click_commute);
        _exit = transform.Find("exit").GetComponent<Button>();
        _exit.onClick.AddListener(click_exit);
        _time = transform.Find("time").GetComponent<Button>();
        _time.onClick.AddListener(click_time);
    }

    private void click_time()
    {
        date.SetActive(true);
        commute.SetActive(false);
    }

    private void click_exit()
    {
        design.SetActive(false);
    }

    private void click_commute()
    {
        commute.SetActive(true);
        date.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
