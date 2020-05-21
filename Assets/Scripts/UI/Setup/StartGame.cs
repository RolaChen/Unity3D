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

        UserData.instance.location.Add("Iron", new Vector3(-8.8f, 0, 92f));
        UserData.instance.location.Add("Copper", new Vector3(85.6f, 0, 102.2f));
        UserData.instance.location.Add("Yin", new Vector3(183.3f, 0, 74.3f));
        UserData.instance.location.Add("Sliver", new Vector3(126.7f, 0, 92.6f));
        UserData.instance.location.Add("Hospital", new Vector3(177.2f, 0, 122.9f));
        UserData.instance.location.Add("SchoolSceneDay", new Vector3(150f, 0, 107.8f));
        UserData.instance.location.Add("PoliceOffice", new Vector3(288.6f, 0, 92.2f));
        UserData.instance.location.Add("Shop", new Vector3(53.2f, 0, 91.8f));
        UserData.instance.location.Add("Dentist", new Vector3(1.3f, 0, -7.2f));
        UserData.instance.location.Add("TCM", new Vector3(-1.4f, 0, -8.7f));
        UserData.instance.location.Add("Psychiatrist", new Vector3(1.5f, 0, 11.7f));

        UserData.instance.salary.Add("实习生", 2500);
        UserData.instance.salary.Add("住院医师", 4000);

        UserData.instance.home.Add("Iron", 25);
        UserData.instance.home.Add("Copper", 35);
    }

}
