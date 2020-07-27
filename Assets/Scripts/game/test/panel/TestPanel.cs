using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel :MyPanel
{
    RectTransform drag;
    public TestPanel() {
        _panelResName = "TestPanel";
    }

    public override void InitPanel()
    {
        base.InitPanel();
        drag = gameObject.FindChild("drag").transform as RectTransform;
    }


    public override void OnClick(MonoBehaviour behaviour)
    {
        base.OnClick(behaviour);
        Debug.Log("OnClick--");
    }

    public override void OnDrag(MyDragData myDragData)
    {
        base.OnDrag(myDragData);
        if(myDragData.go.name== "drag")
            drag.anchoredPosition = myDragData.uiPos;
    }
}

