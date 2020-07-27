using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TestControl :SmartControl<TestModel>
{
    List<MyPanel> myPanels = new List<MyPanel>();
    //数据域

    public B2C_GET _b2C_GET;
    public B2C_GET b2C_GET {
        set {
            _b2C_GET = value;
            //同步界面
            UpdatePanel(value);
        }
        get {
            return _b2C_GET;
        }
    }

    public override void OnAppInit()
    {
        base.OnAppInit();
        MyGUIManager.GetInstance().GetOrCreatePanel<TestPanel>().Display(true);
    }
    #region 公用方法
    public void AddPanel<T>() where T : PanelBase, new()
    {
        var panel=MyGUIManager.GetInstance().GetOrCreatePanel<T>() as MyPanel;
        myPanels.Add(panel);
        panel.Display(true);
    }
    public void RemovePanel<T>() where T : PanelBase, new()
    {
        var panel = MyGUIManager.GetInstance().GetOrCreatePanel<T>() as MyPanel;
        myPanels.Remove(panel);
        panel.Display(false);
    }
    public void UpdatePanel(object obj) {
        foreach (var panel in myPanels) {
            panel.FillData(obj);
        }
    }
    public void Recv() {
        

    }
    #endregion
    #region 数据
    public class B2C_GET {
        public string key = "Value";
    }
    public class B2C_POST
    {
        public string key = "Value";
    }
    #endregion
}
