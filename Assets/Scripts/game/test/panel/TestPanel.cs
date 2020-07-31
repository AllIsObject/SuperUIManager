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
    MyHorizontalLayoutGroup my_hor_Scroll;
    MyHorizontalLayoutGroup content;
    MyImage Image_fade;
    public TestPanel() {
        _panelResName = "TestPanel";
    }

    public override void InitPanel()
    {
        base.InitPanel();
        drag = gameObject.FindChild("drag").transform as RectTransform;
        my_hor_Scroll = gameObject.FindChild("my_hor_Scroll").GetComponent<MyHorizontalLayoutGroup>();
        content = gameObject.FindChild("content").GetComponent<MyHorizontalLayoutGroup>();
        Image_fade = gameObject.FindChild("Image_fade").GetComponent<MyImage>();
    }

    public override void OnShow()
    {
        base.OnShow();
        my_hor_Scroll.InitChildren(5,(i,rect)=> {

        });
        content.InitChildren(10,(i,rect)=> {

        });
        Image_fade.IsFade = true;
    }

    public override void OnClick(MonoBehaviour behaviour)
    {
        base.OnClick(behaviour);
        Debug.Log("OnClick--");
    }

    public override void OnDrag(MyDragData myDragData)
    {
        base.OnDrag(myDragData);
    }

    public override void OnDragEnd(MyDragData myDragData)
    {
        base.OnDragEnd(myDragData);
        Debug.Log($"OnDragEnd-- ui_before_Pos:{myDragData.ui_cur_Pos} ");
    }

    public override void OnDragStart(MyDragData myDragData)
    {
        base.OnDragStart(myDragData);
        Debug.Log($"OnDragStart--  uiPos:{myDragData.ui_before_Pos}");
    }
}

