using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class commute : MonoBehaviour
{
    Button _hospital;
    Button _school;
    Button _police;
    Button _iron;
    Button _copper;
    Button _sliver;
    Button _golden;
    Button _shop;
    Button _home;
    // Start is called before the first frame update
    void Start()
    {
        _hospital = transform.Find("hospital").GetComponent<Button>();
        _hospital.onClick.AddListener(click_hospital);
        _school = transform.Find("school").GetComponent<Button>();
        _school.onClick.AddListener(click_school);
        _police = transform.Find("police").GetComponent<Button>();
        _police.onClick.AddListener(click_police);
        _iron = transform.Find("iron").GetComponent<Button>();
        _iron.onClick.AddListener(click_iron);
        _copper = transform.Find("copper").GetComponent<Button>();
        _copper.onClick.AddListener(click_copper);
        _sliver = transform.Find("sliver").GetComponent<Button>();
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
