using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class select : MonoBehaviour
{
    public GameObject learning;
    public GameObject working;
    public GameObject myself;
    Button _learn;
    Button _work;
    // Start is called before the first frame update
    void Start()
    {
        _learn = transform.Find("learning").GetComponent<Button>();
        _work = transform.Find("working").GetComponent<Button>();
        _learn.onClick.AddListener(click_learn);
        _work.onClick.AddListener(click_work);
    }

    private void click_work()
    {
        working.SetActive(true);
        myself.SetActive(false);
    }

    private void click_learn()
    {
        learning.SetActive(true);
        myself.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
