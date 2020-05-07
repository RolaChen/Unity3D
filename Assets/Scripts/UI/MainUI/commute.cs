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
    Button _golden;
    Button _shop;
    Button _home;
    // Start is called before the first frame update
    void Start()
    {
        _hospital.onClick.AddListener(click_hospital);
        _school.onClick.AddListener(click_school);
        _police.onClick.AddListener(click_police);
        _iron.onClick.AddListener(click_iron);
        _copper.onClick.AddListener(click_copper);
        _sliver.onClick.AddListener(click_sliver);
    }

    private void click_sliver()
    {
        SceneManager.LoadScene("Sliver");
    }

    private void click_copper()
    {
        SceneManager.LoadScene("Copper");
    }

    private void click_iron()
    {
        SceneManager.LoadScene("Iron");
    }

    private void click_police()
    {
        SceneManager.LoadScene("PoliceOffice");
    }

    private void click_school()
    {
        SceneManager.LoadScene("SchoolSceneDay");
    }

    private void click_hospital()
    {
        SceneManager.LoadScene("Hospital");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
