using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserData : Singleton<UserData>
{
    public Dictionary<string, string> map = new Dictionary<string, string>();
}
