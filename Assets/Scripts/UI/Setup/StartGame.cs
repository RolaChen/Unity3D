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
        UserData.instance.map.Add("Hospital", "医院");
        UserData.instance.map.Add("Copper", "千职住宅");
        UserData.instance.map.Add("Iron", "千职公寓");
        UserData.instance.map.Add("Learning", "任务");
        UserData.instance.map.Add("LoginScene", "社区");
        UserData.instance.map.Add("PoliceOffice", "警察局");
        UserData.instance.map.Add("SchoolSceneDay", "学校");
        UserData.instance.map.Add("Shop", "商城");
        UserData.instance.map.Add("Sliver", "千职别墅");
        UserData.instance.map.Add("Yin", "高档公寓");
        Debug.Log(UserData.instance.map["Dentist"]);
    }

}
