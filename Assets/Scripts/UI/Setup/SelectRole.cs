using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRole : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle[] toggles;
    private Button _submit;
    private string _gender="男", _career= "医生";
    void Awake()
    {
        _submit = transform.Find("Enter").GetComponent<Button>();
        _submit.onClick.AddListener(OnBtnSubmitClick);
        int i = 0;
        foreach (Toggle t in toggles)
        {
            int index = i;
            i++;
            t.onValueChanged.AddListener((isOn) => { OnCareerChanged(index, isOn); });
        }
    }
    void OnCareerChanged(int index, bool isOn)
    {
        if(isOn)
        {
            switch(toggles[index].name)
            {
                case "male":
                    _gender = "男";
                    break;
                case "female":
                    _gender = "女";
                    break;
                case "doctor":
                    _career = "医生";
                    break;
                case "teacher":
                    _career = "老师";
                    break;
                case "police":
                    _career = "警察";
                    break;
            }
        }
    }

    void OnBtnSubmitClick()
    {
        Debug.Log(_gender + _career);
    }

}
