using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class LogicMM
{
    public static TestControl testControl = new TestControl();

    /// <summary>
    /// 初始化
    /// </summary>
    public static void FireOnAppInit() {
        foreach (var modlue in ModuleBase.ModuleList) {
            modlue.OnAppInit();

        }
       
    }
}

