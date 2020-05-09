using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UserData.instance.map.Add("TCM", "中医");
        UserData.instance.map.Add("Dentist", "牙医");
        UserData.instance.map.Add("Psychiatrist", "精神科");
        Debug.Log(UserData.instance.map["Dentist"]);
    }

}
