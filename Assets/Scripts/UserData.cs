using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SelectRoleInfo
{
    public string Name;
    public string ModelResPath; //模型资源路径
}
public static class UserData
{
    //假的角色数据
    public static List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();

    static UserData()
    {
        AllRole.Add(new SelectRoleInfo() { Name = "第一个角色", ModelResPath = "" });
        AllRole.Add(new SelectRoleInfo() { Name = "第二个角色", ModelResPath = "" });
        AllRole.Add(new SelectRoleInfo() { Name = "第三个角色", ModelResPath = "" });
    }
}
