using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button exit;

    void Start()
    {
        button1.onClick.AddListener(bt1);
        button2.onClick.AddListener(bt2);
        button3.onClick.AddListener(bt3);
        button4.onClick.AddListener(bt4);
        button5.onClick.AddListener(bt5);
        button6.onClick.AddListener(bt6);
        exit.onClick.AddListener(ex);
    }

    private void ex()
    {
        SceneManager.LoadScene("LoginScene");
    }

    private void bt1()
    {
        PlayerData.instance.money -= 5;
        PlayerData.instance.hunger += 15;
        PlayerData.instance.emotion += 10;
        StartCoroutine(UserData.instance.update());
    }

    private void bt2()
    {
        PlayerData.instance.money -= 35;
        PlayerData.instance.hunger += 30;
        PlayerData.instance.emotion += 40;
        StartCoroutine(UserData.instance.update());
    }

    private void bt3()
    {
        PlayerData.instance.money -= 8;
        PlayerData.instance.hunger += 10;
        PlayerData.instance.emotion += 15;
        StartCoroutine(UserData.instance.update());
    }

    private void bt4()
    {
        PlayerData.instance.money -= 20;
        PlayerData.instance.hunger += 15;
        PlayerData.instance.emotion += 30;
        StartCoroutine(UserData.instance.update());
    }

    private void bt5()
    {
        PlayerData.instance.money -= 100;
        PlayerData.instance.hunger += 80;
        PlayerData.instance.emotion += 70;
        StartCoroutine(UserData.instance.update());

    }

    private void bt6()
    {
        PlayerData.instance.money -= 20;
        PlayerData.instance.hunger += 40;
        PlayerData.instance.emotion += 20;
        StartCoroutine(UserData.instance.update());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
