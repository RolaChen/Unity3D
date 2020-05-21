using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class commute : MonoBehaviour
{
    
    public Button _hospital;
    public Button _school;
    public Button _police;
    public Button _iron;
    public Button _copper;
    public Button _sliver;
    public Button _golden;
    public Button _shop;
    public Button _home;
    // Start is called before the first frame update
    void Start()
    {
        _hospital.onClick.AddListener(click_hospital);
        _school.onClick.AddListener(click_school);
        _police.onClick.AddListener(click_police);
        _iron.onClick.AddListener(click_iron);
        _copper.onClick.AddListener(click_copper);
        _sliver.onClick.AddListener(click_sliver);
        _golden.onClick.AddListener(click_golden);
        _shop.onClick.AddListener(click_shop);
        _home.onClick.AddListener(click_home);
    }

    private void click_home()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene(PlayerData.instance.home);
    }

    private void click_shop()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Shop");
    }

    private void click_golden()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Sliver");
    }

    private void click_sliver()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Yin");
    }

    private void click_copper()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Copper");
    }

    private void click_iron()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Iron");
    }

    private void click_police()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("PoliceOffice");
    }

    private void click_school()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("SchoolSceneDay");
    }

    private void click_hospital()
    {
        PlayerData.instance.money = PlayerData.instance.money - 2;
        StartCoroutine(UserData.instance.update());
        SceneManager.LoadScene("Hospital");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
