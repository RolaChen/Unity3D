using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerData:Singleton<PlayerData>
{
    public string id;
    public string name;
    public string career;
    public string E_career;
    public string gender;
    public string family;
    public string location; //用地图时记录一下想要去的场景是什么
    public int experience;
    public int emotion;
    public int hunger;
    public int money;
    public string level;
    public string address;
    public int month;
    public int day;
    public string time;
    public string pre_Scene;
    public string home;
}
