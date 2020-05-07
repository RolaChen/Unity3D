using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timetable : MonoBehaviour
{
    // Start is called before the first frame update
    public Text month;
    public Text day;
    public Text time;
    void Start()
    {
        month.text = PlayerData.instance.month.ToString();
        day.text = PlayerData.instance.day.ToString();
        time.text = PlayerData.instance.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
